
using Microsoft.EntityFrameworkCore;
using SageX3OutlookDomain.Entities;
using SageX3OutlookDomain.Persistence.Repositories;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly IntegrationDbContext _context;

    public ContactRepository(IntegrationDbContext context) => _context = context;

    public async Task AddAsync(Contact entity) => await _context.Set<Contact>().AddAsync(entity);

    public async Task AddRangeAsync(List<Contact> contacts) => await _context.Set<Contact>().AddRangeAsync(contacts);

    public async Task<IEnumerable<Contact>> GetAllAsync() => await _context.Set<Contact>().ToListAsync();

    public Task<Contact?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Contact entity)
    {
        throw new NotImplementedException();
    }
}
