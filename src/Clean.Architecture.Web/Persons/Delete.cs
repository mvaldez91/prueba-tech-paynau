using FastEndpoints;
using Ardalis.Result;
using MediatR;
using Clean.Architecture.UseCases.Persons.Delete;
using Clean.Architecture.Web.Endpoints.PersonsEndpoints;

namespace Clean.Architecture.Web.PersonEndpoints;

/// <summary>
/// Delete a Person.
/// </summary>
/// <remarks>
/// Delete a Person by providing a valid integer id.
/// </remarks>
public class Delete : Endpoint<DeletePersonRequest>
{
  private readonly IMediator _mediator;

  public Delete(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Delete(DeletePersonRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    DeletePersonRequest request,
    CancellationToken cancellationToken)
  {
    var command = new DeletePersonCommand(request.PersonId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      await SendNoContentAsync(cancellationToken);
    };
    // TODO: Handle other issues as needed
  }
}
