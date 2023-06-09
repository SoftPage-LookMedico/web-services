using AutoMapper;
using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Services;
using LookMedico.API.Payment.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.Payment.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/cardsS/{cardsId}/e_wallets")]
public class CardsE_walletsController:ControllerBase
{
    private readonly IE_walletService _e_walletService;
    private readonly IMapper _mapper;


    public CardsE_walletsController(IE_walletService e_walletService, IMapper mapper)
    {
        _e_walletService = e_walletService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<E_walletResource>> GetAllByCardsId(int cardsId)
    {
        var e_wallets = await _e_walletService.ListByCardsIdAsync(cardsId);
        var resources = _mapper.Map<IEnumerable<E_wallet>, IEnumerable<E_walletResource>>(e_wallets);
        return resources;    
    }
}