using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem> AddAsync(TaskItem task);
    Task<TaskItem?> GetByIdAsync(Guid id);
    Task<List<TaskItem>> GetAllAsync();
    Task UpdateAsync(TaskItem task);
}
