using SageX3OutlookDomain.Entities;

namespace SageX3OutlookApplication.Interfaces;

public interface IUserRepository
{
    Task<User> AddAsync(User user);
    Task<User?> GetByIdAsync(Guid id);
    Task<List<User>> GetAllAsync();
    Task UpdateAsync(User user);
}
