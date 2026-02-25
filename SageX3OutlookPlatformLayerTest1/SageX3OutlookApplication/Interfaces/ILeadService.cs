
using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.LeadsR;
using SageX3OutlookApplication.Responses;

namespace SageX3OutlookApplication.Interfaces;


public interface ILeadService
{
    Task<ApiResponse<LeadDto>> CreateLeadAsync(CreateLeadRequest request);
    Task<LeadDto> CreateAsync(CreateLeadRequest request);
    Task<LeadDto> UpdateAsync(UpdateLeadRequest request);
    Task<List<LeadDto>> GetAllAsync();
}