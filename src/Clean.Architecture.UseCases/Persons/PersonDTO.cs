namespace Clean.Architecture.UseCases.Persons;
public record PersonDTO(int Id, 
                        string FirstName, 
                        string LastName, 
                        string Email, 
                        string PhoneNumber, 
                        string Street, 
                        string City, 
                        string Country, 
                        string ZipCode);
