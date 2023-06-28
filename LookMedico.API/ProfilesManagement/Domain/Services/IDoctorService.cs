public interface IDoctorService
{
    Task<IEnumerable<Doctor>> ListAsync();
    //devuelve un enumerable de doctors

    Task<Doctor> GetByIdAsync(string id);

    Task<DoctorResponse> SaveAsync(Doctor doctor);

    Task<DoctorResponse> UpdateAsync(string id, Doctor doctor);

    Task<DoctorResponse> DeleteAsync(string id);
}
