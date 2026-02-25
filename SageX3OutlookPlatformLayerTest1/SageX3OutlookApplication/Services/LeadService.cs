using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.BusinessRules;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Mapping;
using SageX3OutlookApplication.Requests.LeadsR;
using SageX3OutlookApplication.Responses;
using SageX3OutlookDomain.Entities;



namespace SageX3OutlookApplication.Services;

public class LeadService : ILeadService
{
    private readonly ISageX3Client _sageX3Client;
    private readonly ILeadRepository _repository;

    public LeadService(ISageX3Client sageX3Client, ILeadRepository repository)
    {
        _sageX3Client = sageX3Client;
        _repository = repository;
    }

    public async Task<ApiResponse<LeadDto>> CreateLeadAsync(CreateLeadRequest request)
    {
        Lead lead = request.ToEntity();

        if (!AutoLinkRule.ShouldAutoLink("Lead"))
            return ApiResponse<LeadDto>.Fail("Auto-linking not allowed");

        bool pushed = await _sageX3Client.PushLeadAsync(lead);
        if (!pushed) return ApiResponse<LeadDto>.Fail("Failed to push to ERP");

        // Save to database
        await _repository.AddAsync(lead);

        return ApiResponse<LeadDto>.Ok(lead.ToDto());
    }

    public async Task<LeadDto> CreateAsync(CreateLeadRequest request)
    {
        var lead = request.ToEntity();
        await _repository.AddAsync(lead);
        return lead.ToDto();
    }

    public async Task<List<LeadDto>> GetAllAsync()
    {
        var leads = await _repository.GetAllAsync();
        return leads.Select(l => l.ToDto()).ToList();
    }

    public async Task<LeadDto> UpdateAsync(UpdateLeadRequest request)
    {
        var lead = await _repository.GetAsync(request.Id)
            ?? throw new KeyNotFoundException("Lead not found");

        lead.CompanyName = request.CompanyName ?? string.Empty;
        lead.Email = request.Email ?? string.Empty;
        lead.Phone = request.Phone ?? string.Empty;
        lead.Status = request.Status ?? "New";

        await _repository.UpdateAsync(lead);
        return lead.ToDto();
    }
}

