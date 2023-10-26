using Clean.Architecture.UseCases.Persons;
using Clean.Architecture.UseCases.Persons.List;
using Microsoft.EntityFrameworkCore;

namespace Clean.Architecture.Infrastructure.Data.Queries;

public class ListPersonsQueryService : IListPersonsQueryService
{
  // You can use EF, Dapper, SqlClient, etc. for queries
  private readonly AppDbContext _db;

  public ListPersonsQueryService(AppDbContext db)
  {
    _db = db;
  }

  public async Task<IEnumerable<PersonDTO>> ListAsync()
  {
    // NOTE: This will fail if testing with EF InMemory provider
    var result = await _db.Persons.FromSqlRaw(@"SELECT a.Id, 
                                                       a.FirstName, 
                                                       a.LastName, 
                                                       a.PhoneNumber, 
                                                       a.Email, 
                                                       a.Street, 
                                                       a.City, 
                                                       a.Country, 
                                                       a.ZipCode From Persons a") // don't fetch other big columns
      .Select(c => new PersonDTO(c.Id, 
                                 c.FirstName, 
                                 c.LastName, 
                                 c.Email, 
                                 c.PhoneNumber, 
                                 c.Street,
                                 c.City,
                                 c.Country,
                                 c.ZipCode))
      .ToListAsync();

    return result;
  }
}
