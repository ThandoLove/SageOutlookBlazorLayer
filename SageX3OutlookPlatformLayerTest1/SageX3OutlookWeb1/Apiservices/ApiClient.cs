using System.Net.Http.Json;
using SageX3OutlookApplication.Requests.AttachmentR;
using SageX3OutlookApplication.Requests.KnowledgeR;
using SageX3OutlookApplication.Requests.LeadsR;
using SageX3OutlookApplication.Requests.TasksR;
using SageX3OutlookApplication.Responses;
using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;

namespace SageX3OutlookWeb1.Apiservices;

public class ApiClient : IApiClient
{
    private readonly HttpClient _http;

    public ApiClient(HttpClient http) => _http = http;

    public async Task<List<TaskDto>> GetTasksAsync(CancellationToken ct = default)
    {
        // Adjust "api/tasks" to match your actual API controller route
        return await _http.GetFromJsonAsync<List<TaskDto>>("api/tasks", ct) ?? new List<TaskDto>();
    }

    public async Task<ApiResponse<object>> CreateTaskAsync(CreateTaskRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync("api/tasks/create", request, ct);
        return await response.Content.ReadFromJsonAsync<ApiResponse<object>>(cancellationToken: ct)
               ?? ApiResponse<object>.Fail("No response from server");
    }

    public async Task<ApiResponse<object>> DeleteTaskAsync(Guid id, CancellationToken ct = default)
    {
        var response = await _http.DeleteAsync($"api/tasks/{id}", ct);
        return await response.Content.ReadFromJsonAsync<ApiResponse<object>>(cancellationToken: ct)
               ?? ApiResponse<object>.Fail("Delete failed");
    }

    public async Task<ApiResponse<object>> CreateLeadAsync(CreateLeadRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync("api/leads/create", request, ct);
        return await response.Content.ReadFromJsonAsync<ApiResponse<object>>(cancellationToken: ct) ?? ApiResponse<object>.Fail("No response");
    }

    public async Task<ApiResponse<object>> CreateKnowledgeAsync(CreateKnowledgeRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync("api/knowledge/create", request, ct);
        return await response.Content.ReadFromJsonAsync<ApiResponse<object>>(cancellationToken: ct) ?? ApiResponse<object>.Fail("No response");
    }

    public async Task<ApiResponse<object>> UploadAttachmentAsync(UploadAttachmentRequest request, CancellationToken ct = default)
    {
        var response = await _http.PostAsJsonAsync("api/attachments/upload", request, ct);
        return await response.Content.ReadFromJsonAsync<ApiResponse<object>>(cancellationToken: ct) ?? ApiResponse<object>.Fail("No response");
    }
    // Add this inside public class ApiClient : IApiClient { ... }
    public async Task<List<AuditLogDto>> GetAuditLogsAsync(CancellationToken ct = default)
    {
        // Ensure the endpoint "api/audit" matches your API controller's route
        return await _http.GetFromJsonAsync<List<AuditLogDto>>("api/audit", ct)
               ?? new List<AuditLogDto>();
    }

    public async Task<List<KnowledgeDto>> GetKnowledgeAsync(CancellationToken ct = default)
    {
        // Ensure "api/knowledge" matches your API controller's route
        return await _http.GetFromJsonAsync<List<KnowledgeDto>>("api/knowledge", ct)
               ?? new List<KnowledgeDto>();
    }


}
