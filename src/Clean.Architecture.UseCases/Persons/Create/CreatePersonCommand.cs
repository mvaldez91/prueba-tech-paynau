using Ardalis.Result;

namespace Clean.Architecture.UseCases.Persons.Create;
public record CreatePersonCommand(string FirstName, 
                                 string LastName, 
                                 string Email, 
                                 string PhoneNumber, 
                                 string Street, 
                                 string City, 
                                 string State, 
                                 string ZipCode) : Ardalis.SharedKernel.ICommand<Result<int>>;
