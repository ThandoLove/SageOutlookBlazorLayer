using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class EmailRepository : IEmailRepository
{
    private readonly IntegrationDbContext _context;

    public EmailRepository(IntegrationDbContext context) => _context = context;

    public async Task AddAsync(EmailRecord entity)
    {
        await _context.Set<EmailRecord>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<EmailRecord>> GetAllAsync()
    {
        return await _context.Set<EmailRecord>().ToListAsync();
    }
}
