﻿using Ardalis.Result;
using Ardalis.SharedKernel;
using AutoMapper;
using CityPassGuide.Core.CityPassAggregate;
using CityPassGuide.UseCases.Countries;
using CityPassGuide.UseCases.Countries.Get;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CityPassGuide.UnitTests.UseCases.Countries;

public class GetCountryByIdHandlerTests
{
    private readonly IReadRepository<Country> _repository = Substitute.For<IReadRepository<Country>>();
    private readonly IMapper _mapper = Substitute.For<IMapper>();

    [Fact]
    public async Task Handle_ShouldGetCountryFromRepository()
    {
        // Arrange
        var handler = new GetCountryByIdHandler(_repository, _mapper);
        var query = new GetCountryByIdQuery(1);
        var cancellationToken = new CancellationToken();

        // Act
        await handler.Handle(query, cancellationToken);

        // Assert
        await _repository.Received().GetByIdAsync(query.CountryId, cancellationToken);
    }

    [Fact]
    public async Task Handle_ShouldReturnNotFound_WhenNoCountryFound()
    {
        // Arrange
        var handler = new GetCountryByIdHandler(_repository, _mapper);
        var query = new GetCountryByIdQuery(1);
        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
            .Returns((Country?)null);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Status.Should().Be(ResultStatus.NotFound);
    }

    [Fact]
    public async Task Handle_ShouldMapEntityToDto()
    {
        // Arrange
        var handler = new GetCountryByIdHandler(_repository, _mapper);
        var query = new GetCountryByIdQuery(1);
        var entity = new Country("test_name");
        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
            .Returns(entity);

        // Act
        await handler.Handle(query, CancellationToken.None);

        // Assert
        _mapper.Received().Map<CountryDto>(entity);
    }

    [Fact]
    public async Task Handle_ShouldReturnExpectedResult_WhenCountryFound()
    {
        // Arrange
        var handler = new GetCountryByIdHandler(_repository, _mapper);
        var query = new GetCountryByIdQuery(1);
        var entity = new Country("test_name");
        _repository.GetByIdAsync(Arg.Any<int>(), Arg.Any<CancellationToken>())
            .Returns(entity);
        var dto = new CountryDto(1, "test_name");
        _mapper.Map<CountryDto>(Arg.Any<Country>()).Returns(dto);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.IsSuccess.Should().BeTrue();
        result.Value.Id.Should().Be(dto.Id);
        result.Value.Name.Should().Be(dto.Name);
    }
}
