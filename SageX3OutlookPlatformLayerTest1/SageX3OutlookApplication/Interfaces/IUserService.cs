using SageX3OutlookApplication.DTOs;
using SageX3OutlookApplication.Requests.UserR;

namespace SageX3OutlookApplication.Interfaces;

public interface IUserService
{
    Task<UserDto> CreateAsync(CreateUserRequest request);
    Task<UserDto> UpdateAsync(UpdateUserRequest request);
    Task<List<UserDto>> GetAllAsync();
}
