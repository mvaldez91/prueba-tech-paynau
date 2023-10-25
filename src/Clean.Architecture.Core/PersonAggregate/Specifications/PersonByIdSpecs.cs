using Ardalis.Specification;

namespace Clean.Architecture.Core.PersonAggregate.Specifications;
public class PersonByIdSpecs : Specification<Person>
{
  public PersonByIdSpecs(int id)
  {
    Query.Where(person => person.Id == id);
  }
}
