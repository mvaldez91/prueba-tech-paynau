
using Ardalis.SharedKernel;

namespace Clean.Architecture.Core.PersonAggregate.Events;
internal class PersonUpdatedEvent : DomainEventBase
{
  public PersonUpdatedEvent(Person @new)
  {
  
    New = @new;
  }

  public Person New { get; }
}

