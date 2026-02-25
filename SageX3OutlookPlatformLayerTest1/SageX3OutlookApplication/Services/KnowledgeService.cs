using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.KnowledgeR;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Services;

public class KnowledgeService : IKnowledgeService
{
    private readonly IKnowledgeRepository _repository;

    public KnowledgeService(IKnowledgeRepository repository) => _repository = repository;

    public async Task<KnowledgeDto> CreateAsync(CreateKnowledgeRequest request)
    {
        var entity = new Knowledge { Title = request.Title, Content = request.Content };
        await _repository.AddAsync(entity);
        return new KnowledgeDto { Id = entity.Id, Title = entity.Title, Content = entity.Content };
    }

    public async Task<KnowledgeDto> UpdateAsync(UpdateKnowledgeRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException("Knowledge record not found");

        entity.Title = request.Title ?? string.Empty;
        entity.Content = request.Content ?? string.Empty;
        await _repository.UpdateAsync(entity);
        return new KnowledgeDto { Id = entity.Id, Title = entity.Title };
    }

    public async Task<List<KnowledgeDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new KnowledgeDto { Id = e.Id, Title = e.Title }).ToList();
    }

    public Task CreateKnowledgeAsync(CreateKnowledgeRequest request)
    {
        throw new NotImplementedException();
    }
}
