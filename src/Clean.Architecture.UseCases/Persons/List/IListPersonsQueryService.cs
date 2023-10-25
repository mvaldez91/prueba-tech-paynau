
namespace Clean.Architecture.UseCases.Persons.List;
public interface IListPersonsQueryService
{
  Task<IEnumerable<PersonDTO>> ListAsync();
}
