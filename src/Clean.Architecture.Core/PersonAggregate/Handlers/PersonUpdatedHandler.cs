using Clean.Architecture.Core.PersonAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.PersonAggregate.Handlers;
internal class PersonUpdatedHandler : INotificationHandler<PersonUpdatedEvent>
{
  ILogger<PersonUpdatedHandler> _logger;
  public PersonUpdatedHandler(ILogger<PersonUpdatedHandler> logger)
  {
    _logger = logger;
  }

  public async Task Handle(PersonUpdatedEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Person Updated event for Id={Id}, name={FullName}", domainEvent.New.Id, domainEvent.New.FullName);
    await Task.CompletedTask;
  }
}
