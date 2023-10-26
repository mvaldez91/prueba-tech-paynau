using Clean.Architecture.Core.ContributorAggregate;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.IntegrationTests.Data.Persons;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data;

public class EfRepositoryAddPerson : BaseEfRepoTestFixturePersons
{
  [Fact]
  public async Task AddPersonAndSetIds()
  {
    var repository = GetRepository();
    var person = PersonAggregateHelper.CreatePerson(1);

    await repository.AddAsync(person);

    var newPerson = (await repository.ListAsync())
                    .FirstOrDefault();

    Assert.Equal(person.FirstName, newPerson?.FirstName);
    Assert.Equal(PersonStatus.Enabled, newPerson?.Status);
    Assert.True(newPerson?.Id > 0);
  }
}
