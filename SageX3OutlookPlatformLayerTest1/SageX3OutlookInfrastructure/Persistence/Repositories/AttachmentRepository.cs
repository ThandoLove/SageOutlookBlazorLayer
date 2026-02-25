using Microsoft.EntityFrameworkCore;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
using SageX3OutlookInfrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class AttachmentRepository : IAttachmentRepository
{
    private readonly IntegrationDbContext _context;

    public AttachmentRepository(IntegrationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Attachment entity)
    {
        await _context.Set<Attachment>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Attachment?> GetByIdAsync(Guid id)
    {
        return await _context.Set<Attachment>().FindAsync(id);
    }

    public async Task<List<Attachment>> GetAllAsync()
    {
        return await _context.Set<Attachment>().ToListAsync();
    }

    public async Task UpdateAsync(Attachment entity)
    {
        _context.Set<Attachment>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
