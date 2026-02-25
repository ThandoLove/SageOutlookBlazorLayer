using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Mapping;
using SageX3OutlookApplication.Requests.OpportunitiesR;
using SageX3OutlookDomain.Entities;
using SageX3OutlookApplication.Responses;


namespace SageX3OutlookApplication.Services;

public class OpportunityService : IOpportunityService
{
    private readonly IOpportunityRepository _repository;

    public OpportunityService(IOpportunityRepository repository)
    {
        _repository = repository;
    }

    public async Task<OpportunityDto> CreateAsync(CreateOpportunityRequest request)
    {
        var entity = new Opportunity
        {
            Id = Guid.NewGuid(),
            Name = request.Name ?? string.Empty,
            Account = request.Account ?? string.Empty,
            Value = request.Value, // Ensure both are 'decimal' or 'double'
            Stage = request.Stage ?? string.Empty,
            OwnerId = request.OwnerId
        };

        await _repository.AddAsync(entity); // Added 'await'
        return entity.ToDto();
    }

    public async Task<OpportunityDto> UpdateAsync(UpdateOpportunityRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id)
             ?? throw new InvalidOperationException("Opportunity not found");

        entity.Name = request.Name ?? entity.Name;
        entity.Account = request.Account ?? entity.Account;
        entity.Value = (decimal)request.Value;
        entity.Stage = request.Stage ?? entity.Stage;

        await _repository.UpdateAsync(entity); // Added 'await'
        return entity.ToDto();
    }


    public async Task<List<OpportunityDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(e => e.ToDto()).ToList();
    }
}
