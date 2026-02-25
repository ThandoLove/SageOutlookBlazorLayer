using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.TasksR;
using SageX3OutlookApplication.Responses;

namespace SageX3OutlookApplication.Interfaces;


public interface ITaskService
{
    Task<ApiResponse<TaskDto>> CreateTaskAsync(CreateTaskRequest request);

    Task<TaskDto> CreateAsync(CreateTaskRequest request);
    Task<TaskDto> UpdateAsync(UpdateTaskRequest request);
    Task<List<TaskDto>> GetAllAsync();

}
