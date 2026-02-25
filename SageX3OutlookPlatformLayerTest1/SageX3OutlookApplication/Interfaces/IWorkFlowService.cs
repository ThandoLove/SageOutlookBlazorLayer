using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.WorkflowR;


namespace SageX3OutlookApplication.Interfaces
{
    public interface IWorkFlowService
    {
        Task<WorkflowDto> CreateAsync(CreateWorkflowRequest request);
        Task<WorkflowDto> UpdateAsync(UpdateWorkflowRequest request);
        Task<List<WorkflowDto>> GetAllAsync();
    }
}
