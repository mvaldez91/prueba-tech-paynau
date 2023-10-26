using Clean.Architecture.Web.Person;

namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

public class PersonListResponse
{
  public List<PersonRecord> Persons { get; set; } = new();
}
