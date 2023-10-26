
using Ardalis.Result;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using Clean.Architecture.UseCases.Persons.Update;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Persons;
public class UpdatePersonHandlerHandle
{
  private readonly IUpdatePersonService _updatePersonService;
  private readonly UpdatePersonHandler _handler;

  public UpdatePersonHandlerHandle()
  {
    _updatePersonService = Substitute.For<IUpdatePersonService>();
    _updatePersonService.UpdatePerson(Arg.Any<int>(), Arg.Any<Person>()).Returns(Result.Success());
    _handler = new UpdatePersonHandler(_updatePersonService);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidPerson()
  {
    var result = await _handler.Handle(new UpdatePersonCommand(
      0,
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
