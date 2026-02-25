
using SageX3OutlookDomain.Entities; // Ensure you have an Email entity

namespace SageX3OutlookApplication.Interfaces;

public interface IEmailRepository
{
    Task AddAsync(EmailRecord entity);
    Task<IEnumerable<EmailRecord>> GetAllAsync();
}
