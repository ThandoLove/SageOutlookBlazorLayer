using SageX3OutlookDomain.Entities;


namespace SageX3OutlookApplication.Interfaces;

public interface ILeadRepository
{
    Task AddAsync(Lead lead);
    Task<Lead?> GetAsync(Guid id);
    Task<List<Lead>> GetAllAsync();
    Task UpdateAsync(Lead lead);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
