using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class KnowledgeRepository : IKnowledgeRepository
{
    private static readonly List<Knowledge> _knowledgeRecords = new();

    public Task<Knowledge> AddAsync(Knowledge knowledge)
    {
        _knowledgeRecords.Add(knowledge);
        return Task.FromResult(knowledge);
    }

    public Task<Knowledge?> GetByIdAsync(Guid id)
    {
        var record = _knowledgeRecords.FirstOrDefault(k => k.Id == id);
        return Task.FromResult(record);
    }

    public Task<List<Knowledge>> GetAllAsync()
    {
        return Task.FromResult(_knowledgeRecords.ToList());
    }

    public Task UpdateAsync(Knowledge knowledge)
    {
        var existing = _knowledgeRecords.FirstOrDefault(k => k.Id == knowledge.Id);
        if (existing != null)
        {
            _knowledgeRecords.Remove(existing);
            _knowledgeRecords.Add(knowledge);
        }
        return Task.CompletedTask;
    }
}

