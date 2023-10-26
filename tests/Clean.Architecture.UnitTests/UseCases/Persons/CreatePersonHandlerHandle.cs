
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using Clean.Architecture.UseCases.Persons.Create;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Persons;
public class CreatePersonHandlerHandle
{
  private readonly ICreatePersonService _createPersonService;
  private readonly CreatePersonHandler _handler;  

  public CreatePersonHandlerHandle()
  {
    _createPersonService = Substitute.For<ICreatePersonService>();
    _createPersonService.CreatePerson(Arg.Any<Person>()).ReturnsForAnyArgs(1);
    _handler = new CreatePersonHandler(_createPersonService);
  }

  [Fact]
  public async Task ReturnsCreatedGivenValidPerson()
  {
    
    var result = await _handler.Handle(new CreatePersonCommand(
      PersonAggregateHelper._firstName,
      PersonAggregateHelper._lastName,
      PersonAggregateHelper._email,
      PersonAggregateHelper._phoneNumber,
      PersonAggregateHelper._street,
      PersonAggregateHelper._city,
      PersonAggregateHelper._country,
      PersonAggregateHelper._zipCode
      ), CancellationToken.None);

    result.IsSuccess.Should().BeTrue();
  }
}
