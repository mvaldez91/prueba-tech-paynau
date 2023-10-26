using FastEndpoints;
using Clean.Architecture.Web.Endpoints.PersonsEndpoints;
using Clean.Architecture.UseCases.Persons.Update;
using MediatR;
using Ardalis.Result;
using Clean.Architecture.UseCases.Persons.Get;

namespace Clean.Architecture.Web.PersonsEndpoints;

/// <summary>
/// Update an existing Person.
/// </summary>
/// <remarks>
/// Update an existing Person by providing a fully defined replacement set of values.
/// See: https://stackoverflow.com/questions/60761955/rest-update-best-practice-put-collection-id-without-id-in-body-vs-put-collecti
/// </remarks>
public class Update : Endpoint<UpdatePersonRequest, UpdatePersonResponse>
{

  private readonly IMediator _mediator;

  public Update(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Put(UpdatePersonRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(
    UpdatePersonRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new UpdatePersonCommand(request.Id!,
                                                              request.FirstName!,
                                                              request.LastName!,
                                                              request.Email!,
                                                              request.PhoneNumber!,
                                                              request.Street!,
                                                              request.City!,
                                                              request.Country!,
                                                              request.ZipCode!));

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }
    var existingPerson = await _mediator.Send(new GetPersonQuery(request.Id!));
    if (existingPerson == null)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      var dto = result.Value;
      Response = new UpdatePersonResponse(
        new Person.PersonRecord(dto.Id,
                                dto.FirstName,
                                dto.LastName,
                                dto.Email,
                                dto.PhoneNumber,
                                dto.Street,
                                dto.City,
                                dto.Country,
                                dto.ZipCode));
      return;
    }

  }
}
