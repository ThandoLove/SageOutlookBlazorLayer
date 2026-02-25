using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.OpportunitiesR;


namespace SageX3OutlookApplication.Interfaces
{
    public interface IOpportunityService
    {
        Task<OpportunityDto> CreateAsync(CreateOpportunityRequest request);
        Task<OpportunityDto> UpdateAsync(UpdateOpportunityRequest request);
        Task<List<OpportunityDto>> GetAllAsync();
    }

}
