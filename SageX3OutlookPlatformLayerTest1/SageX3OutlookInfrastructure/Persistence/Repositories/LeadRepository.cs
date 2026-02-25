using Microsoft.EntityFrameworkCore;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;


namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class LeadRepository : ILeadRepository
{
    private readonly IntegrationDbContext _db;

    public LeadRepository(IntegrationDbContext db) => _db = db;

    public async Task AddAsync(Lead lead)
    {
        await _db.Leads.AddAsync(lead);
        await _db.SaveChangesAsync();
    }

    public async Task<Lead?> GetAsync(Guid id) => await _db.Leads.FindAsync(id);

    public async Task<List<Lead>> GetAllAsync() => await _db.Leads.ToListAsync();

    public async Task UpdateAsync(Lead lead)
    {
        _db.Leads.Update(lead);
        await _db.SaveChangesAsync();
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _db.SaveChangesAsync(cancellationToken);
    }
}
