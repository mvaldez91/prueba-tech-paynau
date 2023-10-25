using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.PersonAggregate.Events;
internal class PersonDeletedEvent : DomainEventBase
{
  public PersonDeletedEvent(Person person)
  {
    Person = person;
  }

  public Person Person { get; }
}
