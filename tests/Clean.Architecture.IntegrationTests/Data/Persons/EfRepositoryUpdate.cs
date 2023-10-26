using Clean.Architecture.UnitTests.Core.PersonAggregate;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Clean.Architecture.IntegrationTests.Data.Persons;

public class EfRepositoryUpdate : BaseEfRepoTestFixturePersons
{
  [Fact]
  public async Task UpdatesItemAfterAddingIt()
  {
    // add a Contributor
    var repository = GetRepository();
    var person = PersonAggregateHelper.CreatePerson(null);

    await repository.AddAsync(person);

    // detach the item so we get a different instance
    _dbContext.Entry(person).State = EntityState.Detached;

    // fetch the item and update its title
    var newPerson = (await repository.ListAsync())
        .FirstOrDefault(Person => Person.Email== person.Email);
    if (newPerson == null)
    {
      Assert.NotNull(newPerson);
      return;
    }
    Assert.NotSame(person, newPerson);
    var newName = Guid.NewGuid().ToString();
    newPerson.UpdateContactInfo("change@email.com", "40404040");

    // Update the item
    await repository.UpdateAsync(newPerson);

    // Fetch the updated item
    var updatedItem = (await repository.ListAsync())
        .FirstOrDefault(Contributor => Contributor.Email == "change@email.com");

    Assert.NotNull(updatedItem);
    Assert.NotEqual(person.Email, updatedItem?.Email);
    Assert.Equal(newPerson.Email, updatedItem?.Email);
    Assert.Equal(person.Id, updatedItem?.Id);
  }
}
