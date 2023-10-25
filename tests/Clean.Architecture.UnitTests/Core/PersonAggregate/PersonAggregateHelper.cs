
using Clean.Architecture.Core.Common;
using Clean.Architecture.Core.PersonAggregate;

namespace Clean.Architecture.UnitTests.Core.PersonAggregate;
internal class PersonAggregateHelper
{
  public static readonly string _firstName = "John";
  public static readonly string _lastName = "Doe";
  public static readonly string _email = "demo@email.com";
  public static readonly string _phoneNumber = "1234567890";
  public static readonly string _street = "Bulevar Proceres";
  public static readonly string _city = "Guatemala";
  public static readonly string _state = "GT";
  public static readonly string _zipCode = "01004";

  public static Person CreatePerson()
  {
    return new Person(firstName: _firstName,
                      lastName: _lastName,
                      email: _email,
                      phoneNumber: _phoneNumber,
                      address: new Address(_street, _city, _state, _zipCode));

  }

  public static Person CreateCustomPerson(string firstName, 
                                          string lastName,
                                          string email,
                                          string phoneNumber,
                                          string street
                                          )
  {
    return new Person(firstName: firstName,
                      lastName: lastName,
                      email: email,
                      phoneNumber: phoneNumber,
                      address: new Address(street, _city, _state, _zipCode));

  }
}
