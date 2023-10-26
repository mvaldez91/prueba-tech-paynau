
using Clean.Architecture.Core.PersonAggregate;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.PersonAggregate;
public class PersonConstructor
{


  [Fact]
  public void ShouldCreatePerson()
  {
    var person = PersonAggregateHelper.CreatePerson(1);

    Assert.Equal(PersonAggregateHelper._firstName, person.FirstName);
    Assert.Equal(PersonAggregateHelper._lastName, person.LastName);
    Assert.Equal(PersonAggregateHelper._email, person.Email);
    Assert.Equal(PersonAggregateHelper._phoneNumber, person.PhoneNumber);
    Assert.Equal(PersonAggregateHelper._street, person.Street);
    Assert.Equal(PersonAggregateHelper._city, person.City);
    Assert.Equal(PersonAggregateHelper._country, person.Country);
    Assert.Equal(PersonAggregateHelper._zipCode, person.ZipCode);
    Assert.Equal(PersonStatus.Enabled, person.Status);
  }

  [Fact]
  public void ShouldUpdateName()
  {
    var person = PersonAggregateHelper.CreatePerson(1);
    var newFirstName = "Jane";
    var newLastName = "Doe";

    person.UpdateName(newFirstName, newLastName);

    Assert.Equal(newFirstName, person.FirstName);
    Assert.Equal(newLastName, person.LastName);
  }

  [Fact]
  public void ShouldUpdateContactInfo()
  {
    var person = PersonAggregateHelper.CreatePerson(1);
    var newEmail = "demo2@email.com";
    var newPhoneNumber = "0987654321";
    person.UpdateContactInfo(newEmail, newPhoneNumber);
    Assert.Equal(newEmail, person.Email);
    Assert.Equal(newPhoneNumber, person.PhoneNumber);
  }

  [Fact]
  public void ShouldUpdateAddres()
  {
    var person = PersonAggregateHelper.CreatePerson(1);
    var newStreet = "Quinta Vergara";
    var newCity = "Chile";
    var newCountry = "ES";
    var newZipCode = "040102";
    person.UpdateAddress(country: newCountry,
                         city:newCity,
                         street: newStreet,
                         zipCode: newZipCode);
    Assert.Equal(newStreet, person.Street);
    Assert.Equal(newCity, person.City);
    Assert.Equal(newCountry, person.Country);
    Assert.Equal(newZipCode, person.ZipCode);
  }
  [Fact]
  public void ShouldChangeStatus()
  {
    var person = PersonAggregateHelper.CreatePerson(1);
    var newCountry = PersonStatus.Disabled;
    person.UpdateStatus(newCountry);
    Assert.Equal(newCountry, person.Status);
  }
}
