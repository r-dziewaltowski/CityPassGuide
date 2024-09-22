using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Contributors.Get;

public record GetContributorQuery(int ContributorId) : IQuery<Result<ContributorDTO>>;
