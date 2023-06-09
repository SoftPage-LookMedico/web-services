using AutoMapper;
using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Resources;

namespace LookMedico.API.Payment.Mapping;

public class ResourceToModelProfile: Profile
{
    protected ResourceToModelProfile()
    {
        CreateMap<SaveCardsResource, Cards>();
        CreateMap<SaveCardsResource, E_wallet>();
    }
}