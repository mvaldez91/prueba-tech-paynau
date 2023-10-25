using Ardalis.Result;

namespace Clean.Architecture.Core.Interfaces;
public interface IDeletePersonService
{
  public Task<Result> DeletePerson(int id);
}
