
using Ardalis.Result;
using Clean.Architecture.Core.PersonAggregate;

namespace Clean.Architecture.Core.Interfaces;
public interface ICreatePersonService
{
  public Task<Result<int>> CreatePerson(Person person);
}
