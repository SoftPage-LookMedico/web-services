using AutoMapper;
using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Resources;

namespace LookMedico.API.Payment.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Cards, CardsResource>();
        CreateMap<E_wallet, E_walletResource>();
    }
}