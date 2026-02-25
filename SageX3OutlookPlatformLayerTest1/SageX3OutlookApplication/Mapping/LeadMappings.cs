using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.LeadsR;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Mapping;


public static class LeadMappings
{
    public static LeadDto ToDto(this Lead lead) => new LeadDto
    {
        Id = lead.Id,
        CompanyName = lead.CompanyName,
        Email = lead.Email,
        Phone = lead.Phone,
        Status = lead.Status
    };

    public static Lead ToEntity(this CreateLeadRequest request) => new Lead
    {
        Id = Guid.NewGuid(),
        CompanyName = request.CompanyName,
        Email = request.Email,
        Phone = request.Phone,
        Status = "New"
    };
}