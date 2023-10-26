using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class DeletePersonValidator : Validator<DeletePersonRequest>
{
  public DeletePersonValidator()
  {
    RuleFor(x => x.PersonId)
      .GreaterThan(0);
  }
}
