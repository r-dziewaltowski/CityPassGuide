using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Contributors.Delete;

public record DeleteContributorCommand(int ContributorId) : ICommand<Result>;
