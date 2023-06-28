using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Repositories;
using LookMedico.API.ProfilesManagement.Domain.Services;
using LookMedico.API.ProfilesManagement.Domain.Services.Communication;
using LookMedico.API.Shared.Domain.Repositories;

namespace LookMedico.API.ProfilesManagement.Services;

public class DoctorService: IDoctorService
{
    private readonly IDoctorRepository _doctorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DoctorService(IDoctorRepository doctorRepository, IUnitOfWork unitOfWork)
    {
        _doctorRepository = doctorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Doctor>> ListAsync()
    {
        return await _doctorRepository.ListAsync();
    }

    public async Task<Doctor> GetByIdAsync(string id)
    {
        return await _doctorRepository.FindByIdAsync(id);
    }

    public async Task<DoctorResponse> SaveAsync(Doctor doctor)
    {
        var existingDoctor = await _doctorRepository.FindByIdAsync(doctor.Id);

        if (existingDoctor != null)
            return new DoctorResponse("Username is already user");
        
        try
        {
            await _doctorRepository.AddAsync(doctor);
            await _unitOfWork.CompleteAsync();

            return new DoctorResponse(doctor);
        }
        catch (Exception e)
        {
            return new DoctorResponse($"An error occurred while saving the doctor: {e.Message}");
        }
    }

    public async Task<DoctorResponse> UpdateAsync(string id, Doctor doctor)
    {
        var existingDoctor = await _doctorRepository.FindByIdAsync(id);

        if (existingDoctor == null)
            return new DoctorResponse("Doctor not found");

        existingDoctor.FirstName = doctor.FirstName;
        existingDoctor.LastName = doctor.LastName;
        existingDoctor.Address = doctor.Address;
        existingDoctor.Email = doctor.Email;
        existingDoctor.Phone = doctor.Phone;

        try
        {
            _doctorRepository.Update(existingDoctor);
            await _unitOfWork.CompleteAsync();
            return new DoctorResponse(existingDoctor);
        }
        catch (Exception e)
        {
            return new DoctorResponse($"An error occurred while updating the doctor: {e.Message}");
        }
    }

    public async Task<DoctorResponse> DeleteAsync(string id)
    {
        var existingDoctor = await _doctorRepository.FindByIdAsync(id);

        if (existingDoctor == null)
            return new DoctorResponse("Doctor not found");

        try
        {
            _doctorRepository.Remove(existingDoctor);
            await _unitOfWork.CompleteAsync();
            return new DoctorResponse(existingDoctor);
        }
        catch (Exception e)
        {
            return new DoctorResponse($"$An error occurred while deleting the doctor: {e.Message}");
        }
    }
}
