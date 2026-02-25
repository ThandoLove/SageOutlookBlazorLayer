using Microsoft.EntityFrameworkCore;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookDomain.Entities;
using SageX3OutlookInfrastructure.Persistence;

namespace SageX3OutlookInfrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IntegrationDbContext _context;

    public UserRepository(IntegrationDbContext context)
    {
        _context = context;
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.Set<User>().AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Set<User>().FindAsync(id);
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Set<User>().ToListAsync();
    }

    public async Task UpdateAsync(User user)
    {
        _context.Set<User>().Update(user);
        await _context.SaveChangesAsync();
    }
}
