using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.ContactsR;
using SageX3OutlookDomain.Entities;
using SageX3OutlookDomain.Persistence.Repositories;

namespace SageX3OutlookApplication.Services;

public class ContactService : IContactService
{
    private readonly IContactRepository _repository;

    public ContactService(IContactRepository repository) => _repository = repository;

    // 1. FIXED: Changed return type to Task<ContactDto> so the Controller can receive the result
    public async Task<ContactDto> UpdateAsync(UpdateContactRequest request)
    {
        // Find the entity in the database
        var entity = await _repository.GetByIdAsync(request.Id)
            ?? throw new InvalidOperationException("Contact not found");

        // Map the request data to the entity
        entity.FirstName = request.FirstName ?? string.Empty; ;
        entity.LastName = request.LastName ?? string.Empty; ;
        entity.Email = request.Email ?? string.Empty; 
        entity.Phone = request.Phone ?? string.Empty; 
        entity.Company = request.Company;

        // Persist the changes
        await _repository.UpdateAsync(entity);

        // Return the mapped DTO
        return MapToDto(entity);
    }

    public async Task<ContactDto> CreateAsync(CreateContactRequest request)
    {
        var entity = new Contact
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            Company = request.Company,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(entity);
        return MapToDto(entity);
    }

    public async Task<List<ContactDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(MapToDto).ToList();
    }

    public async Task<ContactDto> UploadAsync(UploadContactRequest request)
    {
        // Simple implementation for single upload; expand if handling bulk
        var entity = new Contact
        {
            Id = Guid.NewGuid(),
            FirstName = "Uploaded",
            LastName = "Contact",
            Email = "uploaded@example.com",
            CreatedAt = DateTime.UtcNow
        };

        await _repository.AddAsync(entity);
        return MapToDto(entity);
    }

    private static ContactDto MapToDto(Contact entity)
    {
        return new ContactDto
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            Phone = entity.Phone,
            Company = entity.Company ?? string.Empty,
            CreatedAt = entity.CreatedAt
        };
    }
}
