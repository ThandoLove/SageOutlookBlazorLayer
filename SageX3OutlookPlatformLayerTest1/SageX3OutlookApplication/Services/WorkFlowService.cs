using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.WorkflowR;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Services;

public class WorkflowService : IWorkFlowService
{
    private readonly IWorkFlowRepository _repository;

    public WorkflowService(IWorkFlowRepository repository)
    {
        _repository = repository;
    }

    public async Task<WorkflowDto> CreateAsync(CreateWorkflowRequest request)
    {
        var entity = new WorkFlow
        {
            ActionType = request.ActionType ?? string.Empty,
            EntityType = request.EntityType ?? string.Empty,
            EntityId = request.EntityId,
            Status = "Pending"
        };

        await _repository.AddAsync(entity);

        return new WorkflowDto
        {
            Id = entity.Id,
            ActionType = entity.ActionType,
            Status = entity.Status
        };
    }

    public async Task<WorkflowDto> UpdateAsync(UpdateWorkflowRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id)
            ?? throw new KeyNotFoundException("Workflow action not found");

        entity.Status = request.Status ?? string.Empty  ;
        await _repository.UpdateAsync(entity);

        return new WorkflowDto { Id = entity.Id, Status = entity.Status };
    }

    public async Task<List<WorkflowDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => new WorkflowDto
        {
            Id = e.Id,
            ActionType = e.ActionType,
            Status = e.Status
        }).ToList();
    }

    Task<WorkflowDto> IWorkFlowService.CreateAsync(CreateWorkflowRequest request)
    {
        throw new NotImplementedException();
    }

    Task<WorkflowDto> IWorkFlowService.UpdateAsync(UpdateWorkflowRequest request)
    {
        throw new NotImplementedException();
    }

    Task<List<WorkflowDto>> IWorkFlowService.GetAllAsync()
    {
        throw new NotImplementedException();
    }
}
