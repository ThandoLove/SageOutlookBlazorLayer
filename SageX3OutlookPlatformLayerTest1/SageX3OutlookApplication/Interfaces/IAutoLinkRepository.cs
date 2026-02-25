

using SageX3OutlookDomain.Entities;


namespace SageX3OutlookApplication.Interfaces;

public interface IAutoLinkRepository
{
    Task<AutoLinkResult?> GetByEmailIdAsync(string emailId);
    Task<List<AutoLinkResult>> GetAllAsync();
    Task AddAsync(AutoLinkResult entity);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
