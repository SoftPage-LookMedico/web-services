using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.ProfilesManagement.Persistence.Repositories;

public class DoctorRepository:BaseRepository, IDoctorRepository
{
    public DoctorRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Doctor>> ListAsync()
    {
        return await _context.Doctors.ToListAsync();
    }

    public async Task AddAsync(Doctor doctor)
    {
        await _context.Doctors.AddAsync(doctor);
    }

    public async Task<Doctor> FindByIdAsync(string id)
    {
        return await _context.Doctors.FindAsync(id);
    }

    public void Update(Doctor doctor)
    {
        _context.Doctors.Update(doctor);
    }

    public void Remove(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
    }
}
