namespace Clean.Architecture.Web.Person;

public record PersonRecord(int Id,
                            string FirstName,
                            string LastName,
                            string Email,
                            string PhoneNumber,
                            string Street,
                            string City,
                            string Country,
                            string ZipCode);
