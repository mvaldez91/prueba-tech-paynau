
using Clean.Architecture.Web.Person;

namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

public class UpdatePersonResponse
{
  public UpdatePersonResponse(PersonRecord person)
  {
    Person = person;
  }
  public PersonRecord Person { get; set; }
}
