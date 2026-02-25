using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.ContactsR;

namespace SageX3OutlookApplication.Interfaces;

public interface IContactService
{
    Task<ContactDto> CreateAsync(CreateContactRequest request);
    Task<ContactDto> UploadAsync(UploadContactRequest request);
    Task<List<ContactDto>> GetAllAsync();

    Task<ContactDto> UpdateAsync(UpdateContactRequest request);

}