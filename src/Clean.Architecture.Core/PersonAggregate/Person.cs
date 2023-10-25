
using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.Common;

namespace Clean.Architecture.Core.PersonAggregate;
public class Person : EntityBase, IAggregateRoot
{
  public string FirstName { get; private set; }
  public string LastName { get; private set; }
  public string Email { get; private set; }
  public string PhoneNumber { get; private set; }
  public Address Address { get; private set; }

  public string FullName { get
    {
      return FirstName + " " + LastName;
    } }

  public PersonStatus Status { get; private set; } = PersonStatus.Enabled;

  public Person(string firstName, 
                string lastName, 
                string email, 
                string phoneNumber, 
                Address address)
  {
    FirstName = Guard.Against.NullOrEmpty(firstName);
    LastName = Guard.Against.NullOrEmpty(lastName);
    Email = Guard.Against.NullOrEmpty(email);
    PhoneNumber = Guard.Against.NullOrEmpty(phoneNumber);
    Address = Guard.Against.Null(address);
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
  public void UpdateAddress(Address address)
  {
    Address = Guard.Against.Null(address);
  }
  public void UpdateStatus(PersonStatus status)
  {
    Status = Guard.Against.Null(status);
  }
}
