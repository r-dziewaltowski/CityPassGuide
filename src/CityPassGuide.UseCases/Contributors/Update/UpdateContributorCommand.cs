using Ardalis.Result;
using Ardalis.SharedKernel;

namespace CityPassGuide.UseCases.Contributors.Update;

public record UpdateContributorCommand(int ContributorId, string NewName) : ICommand<Result<ContributorDTO>>;
