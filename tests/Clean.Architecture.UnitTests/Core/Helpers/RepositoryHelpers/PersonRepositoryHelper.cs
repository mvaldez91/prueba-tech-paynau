
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using NSubstitute;

namespace Clean.Architecture.UnitTests.Core.Helpers.RepositoryHelpers;
public class PersonRepositoryHelper
{

  private static List<Person> repoList = new List<Person>();
  public static IRepository<Person> GetRepository()
  {
    var _repository = Substitute.For<IRepository<Person>>();
    repoList = new List<Person>();
    _repository.ListAsync().Returns(repoList);
    _repository.GetByIdAsync(Arg.Any<int>()).Returns(c => repoList.FirstOrDefault(ind => ind.Id == c.Arg<int>()));
    _repository.AddAsync(Arg.Any<Person>()).Returns(c =>
    {
      repoList.Add(c.Arg<Person>());
      return c.Arg<Person>();
    });
    _repository.When(s => s.UpdateAsync(Arg.Any<Person>())).Do(c =>
    repoList[repoList.FindIndex(ind => ind.Id == c.Arg<Person>().Id)] = c.Arg<Person>());
    return _repository;
  }


}
