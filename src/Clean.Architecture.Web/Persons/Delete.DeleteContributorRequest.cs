namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

public record DeletePersonRequest
{
  public const string Route = "/Persons/{PersonId:int}";
  public static string BuildRoute(int PersonId) => Route.Replace("{PersonId:int}", PersonId.ToString());

  public int PersonId { get; set; }
}
