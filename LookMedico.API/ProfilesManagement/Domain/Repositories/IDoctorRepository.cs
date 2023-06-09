using LookMedico.API.ProfilesManagement.Domain.Models;

namespace LookMedico.API.ProfilesManagement.Domain.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> ListAsync();

    Task AddAsync(Doctor doctor);

    Task<Doctor> FindByIdAsync(string id);

    void Update(Doctor doctor);

    void Remove(Doctor doctor);
}
