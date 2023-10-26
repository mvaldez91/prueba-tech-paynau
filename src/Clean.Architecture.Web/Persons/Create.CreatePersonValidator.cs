using Clean.Architecture.Infrastructure.Data.Config.PersonEntity;
using FastEndpoints;
using FluentValidation;

namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

/// <summary>
/// See: https://fast-endpoints.com/docs/validation
/// </summary>
public class CreatePersonValidator : Validator<CreatePersonRequest>
{
  public CreatePersonValidator()
  {
    RuleFor(x => x.FirstName)
      .NotEmpty()
      .WithMessage("FirstName is required.")
      .MinimumLength(2)
      .MaximumLength(DataSchemaConstants.DEFAULT_FIRST_NAME_LENGTH);
    RuleFor(x => x.LastName)
     .NotEmpty()
     .WithMessage("LastName is required.")
     .MinimumLength(2)
     .MaximumLength(DataSchemaConstants.DEFAULT_LAST_NAME_LENGTH);
    RuleFor(x => x.PhoneNumber)
     .NotEmpty()
     .WithMessage("PhoneNumber is required.")
     .MinimumLength(2)
     .MaximumLength(DataSchemaConstants.DEFAULT_PHONE_NUMBER_LENGTH);
    RuleFor(x => x.Email)
     .NotEmpty()
     .EmailAddress()
     .WithMessage("Email is required.")
     .MinimumLength(10)
     .MaximumLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH);
    RuleFor(x => x.Street)
     .NotEmpty()
     .WithMessage("Street is required.")
     .MinimumLength(2)
     .MaximumLength(DataSchemaConstants.DEFAULT_STREET_LENGTH);
    RuleFor(x => x.Country)
     .NotEmpty()
     .WithMessage("Country is required.")
     .MinimumLength(2)
     .MaximumLength(DataSchemaConstants.DEFAULT_COUNTRY_LENGTH);
    RuleFor(x => x.City)
     .NotEmpty()
     .WithMessage("City is required.")
     .MinimumLength(2)
     .MaximumLength(DataSchemaConstants.DEFAULT_CITY_LENGTH);
    RuleFor(x => x.ZipCode)
     .NotEmpty()
     .WithMessage("ZipCode is required.")
     .MinimumLength(2)
     .MaximumLength(DataSchemaConstants.DEFAULT_ZIP_CODE_LENGTH);

  }
}
