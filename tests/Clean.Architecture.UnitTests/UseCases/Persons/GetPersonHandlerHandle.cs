
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.PersonAggregate.Specifications;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using Clean.Architecture.UseCases.Persons.Get;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.UseCases.Persons;
public class GetPersonHandlerHandle
{
  private readonly GetPersonHandler _getPersonHandler;
  private readonly IReadRepository<Person> _repository;

  public GetPersonHandlerHandle()
  {
    _repository =  Substitute.For<IReadRepository<Person>>();
    _repository.FirstOrDefaultAsync(Arg.Any<PersonByIdSpecs>(), Arg.Any<CancellationToken>()).Returns(
       PersonAggregateHelper.CreatePerson(1)
      );
    _getPersonHandler = new GetPersonHandler(_repository);
  }

  [Fact]
  public async void ReturnsPersonGivenPersonExists()
  {
    var query = new GetPersonQuery(1);
    var result = await _getPersonHandler.Handle(query, CancellationToken.None);

    Assert.Equal(Ardalis.Result.ResultStatus.Ok, result.Status);
    Assert.Equal(1, result.Value.Id);
  }
}
