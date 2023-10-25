using Ardalis.Result;
using Ardalis.SharedKernel;

namespace Clean.Architecture.UseCases.Persons.List;
public class ListPersonsHandler : IQueryHandler<ListPersonsQuery, Result<IEnumerable<PersonDTO>>>
{
  private readonly IListPersonsQueryService _queryService;
  public ListPersonsHandler(IListPersonsQueryService queryService)
  {
    _queryService = queryService;
  }

  public async Task<Result<IEnumerable<PersonDTO>>> Handle(ListPersonsQuery request, CancellationToken cancellationToken)
  {
    var result = await _queryService.ListAsync();
    return Result.Success(result);
  }
}
