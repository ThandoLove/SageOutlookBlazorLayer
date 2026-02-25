using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.KnowledgeR;


namespace SageX3OutlookApplication.Interfaces;

public interface IKnowledgeService
{
    Task<KnowledgeDto> CreateAsync(CreateKnowledgeRequest request);
    Task<KnowledgeDto> UpdateAsync(UpdateKnowledgeRequest request);
    Task<List<KnowledgeDto>> GetAllAsync();
    Task CreateKnowledgeAsync(CreateKnowledgeRequest request);
}
