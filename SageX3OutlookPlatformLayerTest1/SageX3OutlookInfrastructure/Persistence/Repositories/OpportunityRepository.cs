using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class OpportunityRepository : IOpportunityRepository
{
    // Static list for mocking database storage
    private static readonly List<Opportunity> _opportunities = new();

    public Task<Opportunity> AddAsync(Opportunity opportunity)
    {
        _opportunities.Add(opportunity);
        return Task.FromResult(opportunity);
    }

    public Task<Opportunity?> GetByIdAsync(Guid id)
    {
        var opportunity = _opportunities.FirstOrDefault(o => o.Id == id);
        return Task.FromResult(opportunity);
    }

    public Task<List<Opportunity>> GetAllAsync()
    {
        return Task.FromResult(_opportunities.ToList());
    }

    public Task UpdateAsync(Opportunity opportunity)
    {
        var existing = _opportunities.FirstOrDefault(o => o.Id == opportunity.Id);
        if (existing != null)
        {
            _opportunities.Remove(existing);
            _opportunities.Add(opportunity);
        }
        return Task.CompletedTask;
    }
}
