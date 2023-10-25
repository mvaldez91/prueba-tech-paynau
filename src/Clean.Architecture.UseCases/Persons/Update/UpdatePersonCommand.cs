
using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Persons.Update;
public record UpdatePersonCommand(int PersonId,
                                  string NewFirstName,
                                  string NewLastName,
                                  string NewEmail,
                                  string NewPhoneNumber,
                                  string NewStreet,
                                  string NewCity,
                                  string NewState,
                                  string NewZipCode): ICommand<Result<PersonDTO>>;
