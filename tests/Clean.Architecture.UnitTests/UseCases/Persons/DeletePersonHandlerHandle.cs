using Ardalis.Result;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.UseCases.Persons.Delete;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Persons;
public class DeletePersonHandlerHandle
{
  private readonly IDeletePersonService _deletePersonService;
  private readonly DeletePersonHandler _handler;

  public DeletePersonHandlerHandle()
  {
    _deletePersonService = Substitute.For<IDeletePersonService>();
    _deletePersonService.DeletePerson(Arg.Any<int>()).Returns(Result.Success());
    _handler = new DeletePersonHandler(_deletePersonService);
  }

  [Fact]
  public async Task ReturnsSuccessGivenValidPerson()
  {
    var command = new DeletePersonCommand(0);
    var result = await _handler.Handle(command, CancellationToken.None);
    result.IsSuccess.Should().BeTrue();
  }
}
