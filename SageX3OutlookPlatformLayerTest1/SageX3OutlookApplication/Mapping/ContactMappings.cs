using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.ContactsR;
using SageX3OutlookDomain.Entities;


namespace SageX3OutlookApplication.Mapping;

public static class ContactMappings
{
    public static ContactDto ToDto(this Contact contact)
    {
        return new ContactDto
        {
            Id = contact.Id,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            Phone = contact.Phone,
            Company = contact.Company ?? string.Empty,
            CreatedAt = contact.CreatedAt
        };
    }

    public static Contact ToEntity(this CreateContactRequest request)
    {
        return new Contact
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            Company = request.Company,
            CreatedAt = DateTime.UtcNow
        };
    }
}