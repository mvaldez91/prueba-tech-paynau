namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

public class CreatePersonResponse
{
  public CreatePersonResponse(int id, string fullName)
  {
    Id = id;
    FullName = fullName;
  }
  public int Id { get; set; }
  public string FullName { get; set; }
}
