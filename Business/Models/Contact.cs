namespace Business.Models;

public class Contact
{
    // Contact ID
    public string Id { get; set; } = Guid.NewGuid().ToString();
    // Contact förnamn
    public string FirstName { get; set; } = null!;
    // Contact efternamn
    public string LastName { get; set; } = null!;
    // Contact e-postaddress
    public string Email { get; set; } = null!;
    // Contact telefonnummer
    public string PhoneNumber { get; set; } = null!;
    // Contact adress
    public string Address { get; set; } = null!;
    // Contact postnummer
    public string PostalCode { get; set; } = null!;
    // Contact stad/ort
    public string City { get; set; } = null!;
}
