using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.TasksR;
using SageX3OutlookApplication.Responses;
using SageX3OutlookDomain.Entities;



namespace SageX3OutlookApplication.Services;

public class TaskService : ITaskService
{
    private readonly ISageX3Client _sageX3Client;
    private readonly ITaskRepository _repository;

    public TaskService(ISageX3Client sageX3Client, ITaskRepository repository)
    {
        _sageX3Client = sageX3Client;
        _repository = repository;
    }

    public async Task<TaskDto> CreateAsync(CreateTaskRequest request)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Subject = request.Subject ?? request.Title ?? "No Subject",
            Description = request.Description ?? string.Empty,
            DueDate = request.DueDate,
            AssignedTo = request.AssignedTo ?? string.Empty,
        };

        await _repository.AddAsync(task);

        return new TaskDto
        {
            Id = task.Id,
            Subject = task.Subject,
            Description = task.Description
        };
    }

    public async Task<ApiResponse<TaskDto>> CreateTaskAsync(CreateTaskRequest request)
    {
        var task = new TaskItem
        {
            Id = Guid.NewGuid(),
            Subject = request.Subject ?? string.Empty,
            Description = request.Description ?? string.Empty,
            DueDate = request.DueDate,
            AssignedTo = request.AssignedTo ?? string.Empty
        };

        bool pushed = await _sageX3Client.PushTaskAsync(task);
        if (!pushed) return ApiResponse<TaskDto>.Fail("Failed to push to ERP");

        await _repository.AddAsync(task);

        return ApiResponse<TaskDto>.Ok(new TaskDto
        {
            Id = task.Id,
            Subject = task.Subject,
            Description = task.Description
        });
    }

    public async Task<List<TaskDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new TaskDto { Id = e.Id, Subject = e.Subject }).ToList();
    }

    public async Task<TaskDto> UpdateAsync(UpdateTaskRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException("Task not found");

        entity.Subject = request.Subject ?? string.Empty;
        entity.Description = request.Description ?? string.Empty;

        await _repository.UpdateAsync(entity);
        return new TaskDto { Id = entity.Id, Subject = entity.Subject };
    }
}
