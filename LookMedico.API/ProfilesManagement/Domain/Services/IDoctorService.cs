using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Services.Communication;

namespace LookMedico.API.ProfilesManagement.Domain.Services;

public interface IDoctorService
{
    Task<IEnumerable<Doctor>> ListAsync();
    //devuelve un enumerable de doctors
    
    Task<DoctorResponse> SaveAsync(Doctor doctor);

    Task<DoctorResponse> UpdateAsync(string id, Doctor doctor);

    Task<DoctorResponse> DeleteAsync(string id);
}
