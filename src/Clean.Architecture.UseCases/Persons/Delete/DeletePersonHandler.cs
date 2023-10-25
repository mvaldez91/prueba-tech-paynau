
using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;

namespace Clean.Architecture.UseCases.Persons.Delete;
public class DeletePersonHandler : ICommandHandler<DeletePersonCommand, Result>
{
  private readonly IDeletePersonService _deletePersonService;
  public DeletePersonHandler(IDeletePersonService deletePersonService)
  {
    _deletePersonService = deletePersonService;
  }

  public Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
  {
    return _deletePersonService.DeletePerson(request.PersonId);
  }
}
