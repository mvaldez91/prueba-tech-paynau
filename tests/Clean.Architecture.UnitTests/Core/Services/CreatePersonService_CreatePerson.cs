using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.Services.PersonAggregate;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using MediatR;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.Services;
public class CreatePersonService_CreatePerson
{
  private readonly IRepository<Person> _repository = Helpers.RepositoryHelpers.PersonRepositoryHelper.GetRepository();
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  
  private readonly CreatePersonService _service;
  public CreatePersonService_CreatePerson()
  {
    _service = new CreatePersonService(_repository, _mediator);
  }

  [Fact]
  public async Task ShouldCreatePerson()
  {
    var result = await _service.CreatePerson(PersonAggregateHelper.CreatePerson(1));
    Assert.True(result.IsSuccess);
  }

}
