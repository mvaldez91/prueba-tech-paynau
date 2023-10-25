using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.Services.PersonAggregate;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using MediatR;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.Services;
public class UpdatePersonService_UpdatePerson
{

  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator = Substitute.For<IMediator>();

  private readonly UpdatePersonService _service;

  public UpdatePersonService_UpdatePerson()
  {
    _repository = Helpers.RepositoryHelpers.PersonRepositoryHelper.GetRepository();
    _service = new UpdatePersonService(_repository, _mediator);
  }

  [Fact]

  public async Task ReturnsNotFoundGivenCantFindPerson()
  {
    var person = PersonAggregateHelper.CreatePerson();
    var result = await _service.UpdatePerson(person);
    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }

  [Fact]
  public async Task ShouldUpdatePerson()
  {
    var newPerson = PersonAggregateHelper.CreatePerson();
    var createdPerson = await _repository.AddAsync(newPerson);

    var personToUpdate = await _repository.GetByIdAsync(createdPerson.Id);
    if (personToUpdate != null)
    {
      personToUpdate.UpdateName("New Name", "New Last Name");
      var result = await _service.UpdatePerson(personToUpdate);
      Assert.True(result.IsSuccess);
    }
  }
}

