using AutoMapper;
using LookMedico.API.Security.Domain.Models;
using LookMedico.API.Security.Domain.Services.Communication;
using LookMedico.API.Security.Resources;

namespace LookMedico.API.Security.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<User, AuthenticateResponse>();
        CreateMap<User, UserResource>();
    }
    
}
