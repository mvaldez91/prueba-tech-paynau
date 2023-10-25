
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using Clean.Architecture.UseCases.Persons;
using Clean.Architecture.UseCases.Persons.List;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Persons;
public class ListPersonsHandlerHandle
{
  private readonly IListPersonsQueryService _listPersonsQueryService;
  private readonly ListPersonsHandler _listPersonsHandler;
  public ListPersonsHandlerHandle()
  {
    _listPersonsQueryService = Substitute.For<IListPersonsQueryService>();
    _listPersonsQueryService.ListAsync().Returns(new List<PersonDTO> { 
       new PersonDTO(Id: 1, 
                     FirstName: PersonAggregateHelper._firstName, 
                     LastName: PersonAggregateHelper._lastName, 
                     Email: PersonAggregateHelper._email, 
                     PhoneNumber: PersonAggregateHelper._phoneNumber, 
                     Street: PersonAggregateHelper._street,
                     City: PersonAggregateHelper._city,
                     State: PersonAggregateHelper._state, 
                     ZipCode: PersonAggregateHelper._zipCode)
    });
    _listPersonsHandler = new ListPersonsHandler(_listPersonsQueryService);

  }

  [Fact]
  public async void ReturnsPersons()
  {
    var query = new ListPersonsQuery(null, null);
    var result = await _listPersonsHandler.Handle(query, CancellationToken.None);

    Assert.Equal(Ardalis.Result.ResultStatus.Ok, result.Status);
    Assert.Single(result.Value);
  }
}
