using SageX3OutlookDomain.Entities;



namespace SageX3OutlookApplication.Interfaces;

public interface IOpportunityRepository
{
    Task<Opportunity> AddAsync(Opportunity opportunity);
    Task<Opportunity?> GetByIdAsync(Guid id);
    Task<List<Opportunity>> GetAllAsync();
    Task UpdateAsync(Opportunity entity);
}

