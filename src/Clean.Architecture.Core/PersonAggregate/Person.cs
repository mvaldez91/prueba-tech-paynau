
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;


namespace Clean.Architecture.Core.PersonAggregate;
public class Person : EntityBase, IAggregateRoot
{
  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public string Email { get; private set; }
  public string PhoneNumber { get; private set; }
  public string Street { get; private set; }
  public string City { get; private set; }
  public string Country { get; private set; }
  public string ZipCode { get; private set; }


  public string FullName { get
    {
      return FirstName + " " + LastName;
    } }

  public PersonStatus Status { get; private set; } = PersonStatus.Enabled;

  public Person(string firstName, 
                string lastName, 
                string email, 
                string phoneNumber, 
                string country,
                string city,
                string street,
                string zipCode)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName);
    LastName = Guard.Against.NullOrEmpty(lastName);
    Email = Guard.Against.NullOrEmpty(email);
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
    Country = Guard.Against.NullOrEmpty(country);
    City = Guard.Against.NullOrEmpty(city);
    Street = Guard.Against.NullOrEmpty(street); 
    ZipCode = Guard.Against.NullOrEmpty(zipCode);


  }
  public void UpdateName(string firstName, string lastName)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName);
    LastName = Guard.Against.NullOrEmpty(lastName);
  }
  public void UpdateContactInfo(string email, string phoneNumber)
  {
    Email = Guard.Against.NullOrEmpty(email);
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
  }
  public void UpdateAddress(string country, string city,string street, string zipCode)
  {
    Country = Guard.Against.NullOrEmpty(country);
    City = Guard.Against.NullOrEmpty(city);
    Street = Guard.Against.NullOrEmpty(street);
    ZipCode = Guard.Against.NullOrEmpty(zipCode);
  }
  public void UpdateStatus(PersonStatus status)
  {
    Status = Guard.Against.Null(status);
  }
}
