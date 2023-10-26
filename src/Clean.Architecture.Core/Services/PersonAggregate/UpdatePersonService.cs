using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.PersonAggregate.Events;
using MediatR;

namespace Clean.Architecture.Core.Services.PersonAggregate;
public class UpdatePersonService : IUpdatePersonService
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator;

  public UpdatePersonService(IRepository<Person> repository,
                             IMediator mediator)
  {
    _repository = repository;
    _mediator = mediator;
  }
  public async Task<Result> UpdatePerson(int personId, Person person)
  {
    var aggregateToUpdate = await _repository.GetByIdAsync(personId);
    if (aggregateToUpdate == null) return Result.NotFound();
    aggregateToUpdate.UpdateName(person.FirstName, person.LastName);
    aggregateToUpdate.UpdateAddress(person.Country, person.City, person.Street, person.ZipCode);
    aggregateToUpdate.UpdateContactInfo(person.Email, person.PhoneNumber);

    await _repository.UpdateAsync(aggregateToUpdate);
    await _mediator.Publish(new PersonUpdatedEvent(person));
    return Result.Success();
  }
}
