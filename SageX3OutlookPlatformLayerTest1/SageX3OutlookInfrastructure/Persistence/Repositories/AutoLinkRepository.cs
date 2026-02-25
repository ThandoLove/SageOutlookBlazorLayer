using Microsoft.EntityFrameworkCore;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
using SageX3OutlookInfrastructure.Persistence;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class AutoLinkRepository : IAutoLinkRepository
{
    private readonly IntegrationDbContext _context;

    public AutoLinkRepository(IntegrationDbContext context)
    {
        _context = context;
    }

    public async Task<AutoLinkResult?> GetByEmailIdAsync(string emailId)
    {
        // Replace 'AutoLinks' with the actual DbSet name in your DbContext
        return await _context.Set<AutoLinkResult>()
            .FirstOrDefaultAsync(x => x.EmailId == emailId);
    }

    public async Task<List<AutoLinkResult>> GetAllAsync()
    {
        return await _context.Set<AutoLinkResult>().ToListAsync();
    }

    public async Task AddAsync(AutoLinkResult entity)
    {
        await _context.Set<AutoLinkResult>().AddAsync(entity);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}
