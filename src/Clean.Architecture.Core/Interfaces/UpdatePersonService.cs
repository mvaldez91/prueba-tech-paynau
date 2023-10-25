
using Ardalis.Result;
using Clean.Architecture.Core.PersonAggregate;

namespace Clean.Architecture.Core.Interfaces;
public interface IUpdatePersonService
{
  public Task<Result> UpdatePerson(Person person);
}
