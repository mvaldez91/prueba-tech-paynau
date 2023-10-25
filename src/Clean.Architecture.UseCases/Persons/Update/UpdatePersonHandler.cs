using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.PersonAggregate;

namespace Clean.Architecture.UseCases.Persons.Update;
public class UpdatePersonHandler : ICommandHandler<UpdatePersonCommand, Result<PersonDTO>>
{
  IUpdatePersonService _updatePersonService;
  public UpdatePersonHandler(IUpdatePersonService updatePersonService)
  {
    _updatePersonService = updatePersonService;
  }

  public async Task<Result<PersonDTO>> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
  {
    var updatedPerson = new Person(request.NewFirstName,
                             request.NewLastName,
                             request.NewEmail,
                             request.NewPhoneNumber,
                             new Core.Common.Address(request.NewStreet,
                                                     request.NewCity,
                                                     request.NewState,
                                                     request.NewZipCode)
                             );

    var result =await _updatePersonService.UpdatePerson(request.PersonId, updatedPerson);
    if (result.IsSuccess)
    {
      return Result.Success(new PersonDTO(request.PersonId,
                                        updatedPerson.FirstName,
                                        updatedPerson.LastName,
                                        updatedPerson.Email,
                                        updatedPerson.PhoneNumber,
                                        updatedPerson.Address.Street,
                                        updatedPerson.Address.City,
                                        updatedPerson.Address.State,
                                        updatedPerson.Address.ZipCode));
    }
    
    return result;
  }
}
