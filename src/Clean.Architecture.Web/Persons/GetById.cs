using FastEndpoints;
using MediatR;
using Ardalis.Result;
using Clean.Architecture.Web.Endpoints.PersonsEndpoints;
using Clean.Architecture.UseCases.Persons.Get;
using Clean.Architecture.Web.Person;

namespace Clean.Architecture.Web.PersonEndpoints;

/// <summary>
/// Get a Person by integer ID.
/// </summary>
/// <remarks>
/// Takes a positive integer ID and returns a matching Person record.
/// </remarks>
public class GetById : Endpoint<GetPersonByIdRequest, PersonRecord>
{
  private readonly IMediator _mediator;

  public GetById(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get(GetPersonByIdRequest.Route);
    AllowAnonymous();
  }

  public override async Task HandleAsync(GetPersonByIdRequest request,
    CancellationToken cancellationToken)
  {
    var command = new GetPersonQuery(request.PersonId);

    var result = await _mediator.Send(command);

    if (result.Status == ResultStatus.NotFound)
    {
      await SendNotFoundAsync(cancellationToken);
      return;
    }

    if (result.IsSuccess)
    {
      Response = new PersonRecord(result.Value.Id, 
                                  result.Value.FirstName, 
                                  result.Value.LastName,
                                  result.Value.Email,
                                  result.Value.PhoneNumber,
                                  result.Value.Street,
                                  result.Value.City,
                                  result.Value.Country,
                                  result.Value.ZipCode
                                  );
    }
  }
}
