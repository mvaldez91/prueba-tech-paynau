using Clean.Architecture.Core.PersonAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.PersonAggregate.Handlers;
internal class PersonCreatedHandler :INotificationHandler<PersonCreatedEvent>
{
  private readonly ILogger<PersonCreatedHandler> _logger;

  public PersonCreatedHandler(ILogger<PersonCreatedHandler> logger)
  {
    _logger = logger;
  }
  public async Task Handle(PersonCreatedEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Person Created event for Id={Id}, name={FullName}", domainEvent.Person.Id, domainEvent.Person.FullName);
    await Task.CompletedTask;
  }
}
