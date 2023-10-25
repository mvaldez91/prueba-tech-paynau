
using Clean.Architecture.Core.Common;
using Clean.Architecture.Core.PersonAggregate;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.PersonAggregate;
public class PersonConstructor
{


  [Fact]
  public void ShouldCreatePerson()
  {
    var person = PersonAggregateHelper.CreatePerson();

    Assert.Equal(PersonAggregateHelper._firstName, person.FirstName);
    Assert.Equal(PersonAggregateHelper._lastName, person.LastName);
    Assert.Equal(PersonAggregateHelper._email, person.Email);
    Assert.Equal(PersonAggregateHelper._phoneNumber, person.PhoneNumber);
    Assert.Equal(PersonAggregateHelper._street, person.Address.Street);
    Assert.Equal(PersonAggregateHelper._city, person.Address.City);
    Assert.Equal(PersonAggregateHelper._state, person.Address.State);
    Assert.Equal(PersonAggregateHelper._zipCode, person.Address.ZipCode);
    Assert.Equal(PersonStatus.Enabled, person.Status);
  }

  [Fact]
  public void ShouldUpdateName()
  {
    var person = PersonAggregateHelper.CreatePerson();
    var newFirstName = "Jane";
    var newLastName = "Doe";

    person.UpdateName(newFirstName, newLastName);

    Assert.Equal(newFirstName, person.FirstName);
    Assert.Equal(newLastName, person.LastName);
  }

  [Fact]
  public void ShouldUpdateContactInfo()
  {
    var person = PersonAggregateHelper.CreatePerson();
    var newEmail = "demo2@email.com";
    var newPhoneNumber = "0987654321";
    person.UpdateContactInfo(newEmail, newPhoneNumber);
    Assert.Equal(newEmail, person.Email);
    Assert.Equal(newPhoneNumber, person.PhoneNumber);
  }

  [Fact]
  public void ShouldUpdateAddres()
  {
    var person = PersonAggregateHelper.CreatePerson();
    var newStreet = "Quinta Vergara";
    var newCity = "Chile";
    var newState = "ES";
    var newZipCode = "040102";
    person.UpdateAddress(new Address(newStreet,newCity, newState, newZipCode));
    Assert.Equal(newStreet, person.Address.Street);
    Assert.Equal(newCity, person.Address.City);
    Assert.Equal(newState, person.Address.State);
    Assert.Equal(newZipCode, person.Address.ZipCode);
  }
  [Fact]
  public void ShouldChangeStatus()
  {
    var person = PersonAggregateHelper.CreatePerson();
    var newState = PersonStatus.Disabled;
    person.UpdateStatus(newState);
    Assert.Equal(newState, person.Status);
  }
}
