using FastEndpoints;
using MediatR;
using Clean.Architecture.Web.Endpoints.PersonsEndpoints;
using Clean.Architecture.UseCases.Persons.List;
using Clean.Architecture.Web.Person;

namespace Clean.Architecture.Web.PersonsEndpoints;

/// <summary>
/// List all Persons
/// </summary>
/// <remarks>
/// List all Persons - returns a PersonListResponse containing the Persons.
/// </remarks>
public class List : EndpointWithoutRequest<PersonListResponse>
{
  private readonly IMediator _mediator;

  public List(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Get("/Persons");
    AllowAnonymous();
  }

  public override async Task HandleAsync(CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new ListPersonsQuery(null, null));

    if (result.IsSuccess)
    {
      Response = new PersonListResponse
      {
        Persons = result.Value.Select(c => new PersonRecord(c.Id, c.FirstName, c.LastName, c.Email, c.PhoneNumber, c.Street, c.City, c.Country, c.ZipCode)).ToList()
      };
    }
  }
}
