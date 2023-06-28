using LookMedico.API.Security.Domain.Models;
using LookMedico.API.Security.Domain.Services.Communication;
using LookMedico.API.Security.Exceptions;

namespace LookMedico.API.Security.Domain.Services;

public interface IUserService
{
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(string id);
    Task DeleteAsync(string id);
    
    Task<UserResponse> SaveAsync(User user);
}