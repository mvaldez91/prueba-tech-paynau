using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.PersonAggregate.Events;
using MediatR;

namespace Clean.Architecture.Core.Services.PersonAggregate;
public class DeletePersonService : IDeletePersonService
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator;

  public DeletePersonService(IRepository<Person> repository,
                                IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }

  public async Task<Result> DeletePerson(int id)
  {
    var aggregateToDelete = await _repository.GetByIdAsync(id);
    if (aggregateToDelete == null) return Result.NotFound();
    await _repository.DeleteAsync(aggregateToDelete);
    await _mediator.Publish(new PersonDeletedEvent(aggregateToDelete));
    return Result.Success();
  }
}
