using LookMedico.API.Security.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.Security.Domain.Services.Communication;

public class UserResponse: BaseResponse<User>
{
    public UserResponse(string message) : base(message)
    {
    }

    public UserResponse(User resource) : base(resource)
    {
    }
}