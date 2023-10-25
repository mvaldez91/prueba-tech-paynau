using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;

namespace Clean.Architecture.Core.Common;
public class Address
{
  public string Street { get; private set; }
  public string City { get; private set; }
  public string State { get; private set; }
  public string ZipCode { get; private set; }

  public Address(string street, string city, string state, string zipCode)
  {
    Street = Guard.Against.NullOrEmpty(street);
    City = Guard.Against.NullOrEmpty(city);
    State = Guard.Against.NullOrEmpty(state);
    ZipCode = Guard.Against.NullOrEmpty(zipCode);
  }
}
