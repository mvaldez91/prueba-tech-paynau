
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
  public static readonly string _country = "GT";
  public static readonly string _zipCode = "01004";

  public static Person CreatePerson(int? id)
  {

    var person = new Person(firstName: _firstName,
                      lastName: _lastName,
                      email: _email,
                      phoneNumber: _phoneNumber,
                      street: _street, 
                      city: _city, 
                      country: _country,
                      zipCode: _zipCode);
    if (id.HasValue) {
      person.Id = id.Value;
    }
    
    return person;

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
                      street: street,
                      city: _city,
                      country: _country,
                      zipCode: _zipCode
                      );

  }
}
