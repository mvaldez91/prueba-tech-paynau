using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.PersonAggregate.Events;
using MediatR;

namespace Clean.Architecture.Core.Services.PersonAggregate;
public class CreatePersonService : ICreatePersonService
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator;

  public CreatePersonService(IRepository<Person> repository,
                             IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }
  public async Task<Result> CreatePerson(Person person)
  {
     await _repository.AddAsync(person);
     await _mediator.Publish(new PersonCreatedEvent(person));
    return Result.Success();
  }
}
