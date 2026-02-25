using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class TaskRepository : ITaskRepository
{
    // Static list for mocking database storage
    private static readonly List<TaskItem> _tasks = new();

    public Task<TaskItem> AddAsync(TaskItem task)
    {
        _tasks.Add(task);
        return Task.FromResult(task);
    }

    public Task<TaskItem?> GetByIdAsync(Guid id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        return Task.FromResult(task);
    }

    public Task<List<TaskItem>> GetAllAsync()
    {
        return Task.FromResult(_tasks.ToList());
    }

    public Task UpdateAsync(TaskItem task)
    {
        var existing = _tasks.FirstOrDefault(t => t.Id == task.Id);
        if (existing != null)
        {
            _tasks.Remove(existing);
            _tasks.Add(task);
        }
        return Task.CompletedTask;
    }
}

