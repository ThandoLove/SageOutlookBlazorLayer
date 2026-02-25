using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
public class EmailService : IEmailService
{
    private readonly IEmailRepository _repository; // Use the Interface 'I'

    public EmailService(IEmailRepository repository)
    {
        _repository = repository;
    }

    public async Task<EmailDto> CreateEmailRecordAsync(EmailDto email)
    {
        // Ensure you have these .ToEntity() and .ToDto() extensions 
        // or map them manually like we did for Contacts
        var entity = new EmailRecord { /* mapping logic */ };
        await _repository.AddAsync(entity);
        return email;
    }

    public async Task<List<EmailDto>> GetAllEmailsAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new EmailDto { /* map */ }).ToList();
    }
}

