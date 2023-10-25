using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.PersonAggregate;

namespace Clean.Architecture.UseCases.Persons.Create;
public class CreatePersonHandler : ICommandHandler<CreatePersonCommand, Result<int>>
{
  private readonly ICreatePersonService _createPersonService;
  public CreatePersonHandler(ICreatePersonService createPersonService)
  {
    _createPersonService = createPersonService;
  }

  public async Task<Result<int>> Handle(CreatePersonCommand request, 
                                  CancellationToken cancellationToken)
  {
    var newPerson = new Person(request.FirstName, 
                               request.LastName, 
                               request.Email, 
                               request.PhoneNumber,
                               new Core.Common.Address(request.Street, 
                                                       request.City, 
                                                       request.State, 
                                                       request.ZipCode)
                               );
    
    var result = await _createPersonService.CreatePerson(newPerson);
    return result.Value;
  }
}
