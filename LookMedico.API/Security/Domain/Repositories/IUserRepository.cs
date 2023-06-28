using LookMedico.API.Security.Domain.Models;

namespace LookMedico.API.Security.Domain.Repositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> ListAsync();
    Task AddAsync(User user);
    Task<User> FindByIdAsync(string id);
    User FindById(string id);
    
    bool ExistsById(string id);

    void Remove(User user);

}
