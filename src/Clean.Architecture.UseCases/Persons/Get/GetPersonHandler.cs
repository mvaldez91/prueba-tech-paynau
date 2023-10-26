using Ardalis.Result;
using Ardalis.SharedKernel;
using Clean.Architecture.Core.PersonAggregate;
using Clean.Architecture.Core.PersonAggregate.Specifications;

namespace Clean.Architecture.UseCases.Persons.Get;
public class GetPersonHandler : IQueryHandler<GetPersonQuery, Result<PersonDTO>>
{
  private IReadRepository<Person> _repository;
  public GetPersonHandler(IReadRepository<Person> repository)
  {
    _repository = repository;
  }

  public async Task<Result<PersonDTO>> Handle(GetPersonQuery request, CancellationToken cancellationToken)
  {
    var spec = new PersonByIdSpecs(request.PersonId);
    var entity = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
    if (entity == null)
    {
      return Result.NotFound();
    }
    return new PersonDTO(
      Id: entity.Id,
      FirstName: entity.FirstName,
      LastName: entity.LastName,
      Email: entity.Email,
      PhoneNumber: entity.PhoneNumber,
      Street: entity.Street, 
      City: entity.City, 
      Country: entity.Country,
      ZipCode: entity.ZipCode);   
  }
}
