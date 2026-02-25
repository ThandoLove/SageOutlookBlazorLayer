
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Interfaces;

public interface IWorkFlowRepository
{
    Task AddAsync(WorkFlow entity);
    Task<WorkFlow?> GetByIdAsync(Guid id);
    Task<List<WorkFlow>> GetAllAsync();
    Task UpdateAsync(WorkFlow entity);
}
