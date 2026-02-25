using SageX3OutlookApplication.Requests.TasksR;
using SageX3OutlookApplication.Requests.LeadsR;
using SageX3OutlookApplication.Requests.KnowledgeR;
using SageX3OutlookApplication.Requests.AttachmentR;
using SageX3OutlookApplication.Responses;
using SageX3OutlookApplication.DTOs;

namespace SageX3OutlookWeb1.Apiservices;

public interface IApiClient
{
    // Task Management
    Task<ApiResponse<object>> CreateTaskAsync(CreateTaskRequest request, CancellationToken ct = default);
    Task<List<TaskDto>> GetTasksAsync(CancellationToken ct = default);
    Task<ApiResponse<object>> DeleteTaskAsync(Guid id, CancellationToken ct = default);

    // Other Entities
    Task<ApiResponse<object>> CreateLeadAsync(CreateLeadRequest request, CancellationToken ct = default);
    Task<ApiResponse<object>> CreateKnowledgeAsync(CreateKnowledgeRequest request, CancellationToken ct = default);
    Task<ApiResponse<object>> UploadAttachmentAsync(UploadAttachmentRequest request, CancellationToken ct = default);
    // Add this to your existing IApiClient interface
    Task<List<AuditLogDto>> GetAuditLogsAsync(CancellationToken ct = default);
    // Add to your IApiClient interface
    Task<List<KnowledgeDto>> GetKnowledgeAsync(CancellationToken ct = default);


}
