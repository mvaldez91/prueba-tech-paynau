using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.PersonAggregate.Events;
internal class PersonCreatedEvent : DomainEventBase
{
  public PersonCreatedEvent(Person person)
  {
    Person = person;
  }

  public Person Person { get; }
}
