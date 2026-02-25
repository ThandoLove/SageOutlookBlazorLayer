

namespace SageX3OutlookApplication.Requests.ContactsR;


/// <summary>
/// Represents a request to create a contact in the system.
/// Only Create/Upload operations; Delete is skipped per instructions.
/// </summary>
public class CreateContactRequest
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string Company { get; set; } = null!;
}