using Clean.Architecture.Core.PersonAggregate;
using Ardalis.SharedKernel;
using FastEndpoints;
using Clean.Architecture.Web.Endpoints.PersonsEndpoints;
using MediatR;
using Clean.Architecture.UseCases.Persons.Create;

namespace Clean.Architecture.Web.PersonsEndpoints;

/// <summary>
/// Create a new Person
/// </summary>
/// <remarks>
/// Creates a new Person with his personal data.
/// </remarks>
public class Create : Endpoint<CreatePersonRequest, CreatePersonResponse>
{
  private readonly IMediator _mediator;

  public Create(IMediator mediator)
  {
    _mediator = mediator;
  }

  public override void Configure()
  {
    Post(CreatePersonRequest.Route);
    AllowAnonymous();
    Summary(s =>
    {
      s.ExampleRequest = new CreatePersonRequest { FirstName = "John",
                                                   LastName = "Doe",
                                                   PhoneNumber = "+502505050",
                                                   Email="example@email.com",
                                                   City = "Guatemala",
                                                   Country = "GT",
                                                   Street = "Avenida Bolivar",
                                                   ZipCode = "01001"
                                                };
    });
  }

  public override async Task HandleAsync(
    CreatePersonRequest request,
    CancellationToken cancellationToken)
  {
    var result = await _mediator.Send(new CreatePersonCommand(request.FirstName!, 
                                                              request.LastName!, 
                                                              request.Email!,
                                                              request.PhoneNumber!, 
                                                              request.Street!,
                                                              request.City!, 
                                                              request.Country!, 
                                                              request.ZipCode!));

    if (result.IsSuccess)
    {
      Response = new CreatePersonResponse(result.Value, request.FirstName + " " + request.LastName);
      return;
    }
  }
}
