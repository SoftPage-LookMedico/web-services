using LookMedico.API.Security.Domain.Models;
using LookMedico.API.Security.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.Security.Persistence.Repositories;

public class UserRepository : BaseRepository,IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<User>> ListAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<User> FindByIdAsync(string id)
    {
        return await _context.Users.FindAsync(id);
    }
    
    public User FindById(string id)
    {
        return _context.Users.Find(id);
    }
    
    
    public bool ExistsById(string id)
    {
        return _context.Users.Any(x => x.Id == id);
    }
    
    public void Remove(User user)
    {
        _context.Users.Remove(user);
    }
}
