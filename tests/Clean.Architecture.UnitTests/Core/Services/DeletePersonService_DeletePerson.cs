using System;
using System.Collections.Generic;
using System.Linq;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.Services.PersonAggregate;
using Clean.Architecture.UnitTests.Core.PersonAggregate;
using MediatR;
using NSubstitute;
using Xunit;

namespace Clean.Architecture.UnitTests.Core.Services;

public class DeletePersonService_DeletePerson
{
  private readonly IRepository<Person> _repository;
  private readonly IMediator _mediator = Substitute.For<IMediator>();
  
  private readonly DeletePersonService _service;

  public DeletePersonService_DeletePerson()
  {
    _repository = Helpers.RepositoryHelpers.PersonRepositoryHelper.GetRepository();
    _service = new DeletePersonService(_repository, _mediator);
  }

  [Fact]
  public async Task ReturnsNotFoundGivenCantFindContributor()
  {
    var result = await _service.DeletePerson(0);
    Assert.Equal(Ardalis.Result.ResultStatus.NotFound, result.Status);
  }

  [Fact]
  public async Task ShouldDeletePerson()
  {
    var testPerson = await _repository.AddAsync(PersonAggregateHelper.CreatePerson(1));
    var result =await _service.DeletePerson(testPerson.Id);
    Assert.Equal(Ardalis.Result.ResultStatus.Ok, result.Status);
  }
}
