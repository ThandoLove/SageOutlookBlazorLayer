using SageX3OutlookApplication.DTOs;

namespace SageX3OutlookApplication.Interfaces;

public interface IEmailService
{
    Task<EmailDto> CreateEmailRecordAsync(EmailDto email);
    Task<List<EmailDto>> GetAllEmailsAsync();
}
