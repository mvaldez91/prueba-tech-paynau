using System.ComponentModel.DataAnnotations;

namespace Clean.Architecture.Web.Endpoints.PersonsEndpoints;

public class UpdatePersonRequest
{
  public const string Route = "/Persons/{PersonId:int}";
  public static string BuildRoute(int personId) => Route.Replace("{PersonId:int}", personId.ToString());

  public int PersonId { get; set; }

  [Required]
  public int Id { get; set; }

  [Required]
  public string? FirstName { get; set; }

  [Required]
  public string? LastName { get; set; }
  [Required]
  public string? Email { get; set; }
  [Required]
  public string? PhoneNumber { get; set; }
  [Required]
  public string? Street { get; set; }
  [Required]
  public string? City { get; set; }
  [Required]
  public string? Country { get; set; }
  [Required]
  public string? ZipCode { get; set; }
}
