using Clean.Architecture.Core.PersonAggregate.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Clean.Architecture.Core.PersonAggregate.Handlers;
internal class PersonDeletedHandler : INotificationHandler<PersonDeletedEvent>
{
  private readonly ILogger<PersonDeletedHandler> _logger;
  public PersonDeletedHandler(ILogger<PersonDeletedHandler> logger)
  {
    _logger = logger;
  }
  public async Task Handle(PersonDeletedEvent domainEvent, CancellationToken cancellationToken)
  {
    _logger.LogInformation("Handling Person Deleted event for {personId}", domainEvent.Person.Id);
    await Task.CompletedTask;
  }
}
