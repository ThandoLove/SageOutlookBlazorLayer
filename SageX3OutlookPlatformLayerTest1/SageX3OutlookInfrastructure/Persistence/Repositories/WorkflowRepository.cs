
using Microsoft.EntityFrameworkCore;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class WorkflowRepository : IWorkFlowRepository
{
    private readonly IntegrationDbContext _context;

    public WorkflowRepository(IntegrationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(WorkFlow entity)
    {
        await _context.Set<WorkFlow>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<WorkFlow?> GetByIdAsync(Guid id)
    {
        return await _context.Set<WorkFlow>().FindAsync(id);
    }

    public async Task<List<WorkFlow>> GetAllAsync()
    {
        return await _context.Set<WorkFlow>().ToListAsync();
    }

    public async Task UpdateAsync(WorkFlow entity)
    {
        _context.Set<WorkFlow>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
