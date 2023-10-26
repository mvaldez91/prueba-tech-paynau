using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data.Persons;

public class EfRepositoryDelete : BaseEfRepoTestFixturePersons
{
  [Fact]
  public async Task DeletesItemAfterAddingIt()
  {
    // add a Contributor
    var repository = GetRepository();
    var person = PersonAggregateHelper.CreatePerson(null);
    await repository.AddAsync(person);

    // delete the item
    await repository.DeleteAsync(person);

    // verify it's no longer there
    Assert.DoesNotContain(await repository.ListAsync(),
        Person => Person.FirstName == person.FirstName);
  }
}
