using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Interfaces;
using SageX3OutlookApplication.Requests.UserR;
using SageX3OutlookDomain.Entities;
using SageX3OutlookDomain.Enums;

namespace SageX3OutlookApplication.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;

    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserDto> CreateAsync(CreateUserRequest request)
    {
        var entity = new User
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            Name = request.Name ?? string.Empty,
            Role = ConvertRole(request.Role) // ✅ FIX HERE
        };

        await _repository.AddAsync(entity);
        return MapToDto(entity);
    }

    public async Task<UserDto> UpdateAsync(UpdateUserRequest request)
    {
        var entity = await _repository.GetByIdAsync(request.Id)
            ?? throw new InvalidOperationException("User not found");

        entity.Name = request.FirstName ?? string.Empty;
        entity.Email = request.Email ?? string.Empty;
        entity.Role = ConvertRole(request.Role); // ✅ FIX HERE

        await _repository.UpdateAsync(entity);
        return MapToDto(entity);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();
        return entities.Select(MapToDto).ToList();
    }

    private static UserDto MapToDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FullName = user.Name,
            Email = user.Email,
            Role = user.Role.ToString(),
            IsActive = true
        };
    }

    // ✅ This stays INSIDE UserService
    private static UserRole ConvertRole(string roleString)
    {
        if (!Enum.TryParse<UserRole>(roleString, true, out var role))
            throw new ArgumentException($"Invalid user role: {roleString}");

        return role;
    }
}