using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Interfaces;

public interface IKnowledgeRepository
{
    Task<Knowledge> AddAsync(Knowledge knowledge);
    Task<Knowledge?> GetByIdAsync(Guid id);
    Task<List<Knowledge>> GetAllAsync();
    Task UpdateAsync(Knowledge knowledge);
}
