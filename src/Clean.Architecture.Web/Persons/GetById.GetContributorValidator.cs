using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class GetPersonValidator : Validator<GetPersonByIdRequest>
{
  public GetPersonValidator()
  {
    RuleFor(x => x.PersonId)
      .GreaterThan(0);
  }
}
