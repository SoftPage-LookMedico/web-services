using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.ProfilesManagement.Domain.Services.Communication;

public class DoctorResponse: BaseResponse<Doctor>
{
    public DoctorResponse(string message) : base(message)
    {
    }

    public DoctorResponse(Doctor resource) : base(resource)
    {
    }
}
