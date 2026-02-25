using SageX3OutlookApplication.DTOs;

using SageX3OutlookDomain.Entities;
// Create an alias to avoid conflict with System.Threading.Tasks
using DomainEnums = SageX3OutlookDomain.Enums;

namespace SageX3OutlookApplication.Mapping;

public static class TaskMappings
{
    public static TaskDto ToDto(this TaskItem entity)
    {
        return new TaskDto
        {
            Id = entity.Id,
            Subject = entity.Subject,
            Description = entity.Description,
            AssignedTo = entity.AssignedTo,
            // Use the alias 'DomainEnums' to point to your specific Enum
            Status = entity.Completed ? DomainEnums.TaskStatus.Completed : DomainEnums.TaskStatus.Pending
        };
    }

    public static TaskItem ToEntity(this TaskDto dto)
    {
        return new TaskItem
        {
            Id = dto.Id,
            Subject = dto.Subject,
            Description = dto.Description,
            AssignedTo = dto.AssignedTo,
            // Use the alias here as well
            Completed = dto.Status == DomainEnums.TaskStatus.Completed
        };
    }
}

    


