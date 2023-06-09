using AutoMapper;
using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Services;
using LookMedico.API.Payment.Resources;
using LookMedico.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.Payment.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class E_walletController:ControllerBase
{
    private readonly IE_walletService _e_walletService;
    private readonly IMapper _mapper;
    
    public E_walletController(IE_walletService e_walletService, IMapper mapper)
    {
        _e_walletService = e_walletService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<E_walletResource>> GetAllAsync()
    {
        var e_wallets = await _e_walletService.ListAsync();
        var resources = _mapper.Map<IEnumerable<E_wallet>, IEnumerable<E_walletResource>>(e_wallets);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveE_walletResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var e_wallet = _mapper.Map<SaveE_walletResource, E_wallet>(resource);
        
        var result = await _e_walletService.SaveAsync(e_wallet);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var tutorialResource = _mapper.Map<E_wallet, SaveE_walletResource>(result.Resource);

        return Created(nameof(PostAsync), tutorialResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveE_walletResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var e_wallet = _mapper.Map<SaveE_walletResource, E_wallet>(resource);
        var result = await _e_walletService.UpdateAsync(id, e_wallet);

        if (!result.Success)
            return BadRequest(result.Message);

        var e_walletResource = _mapper.Map<E_wallet, E_walletResource>(result.Resource);
        return Ok(e_walletResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _e_walletService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var e_walletResource = _mapper.Map<E_wallet, E_walletResource>(result.Resource);
        return Ok(e_walletResource);
    }
}
   
