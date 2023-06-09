using System.Net.Mime;
using AutoMapper;
using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Services;
using LookMedico.API.Payment.Resources;
using LookMedico.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace LookMedico.API.Payment.Interfaces.Rest.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CardsController:ControllerBase
{
    private readonly ICardsService _cardsService;
    private readonly IMapper _mapper;


    public CardsController(ICardsService cardsService, IMapper mapper)
    {
        _cardsService = cardsService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CardsResource>), 200)]
    public async Task<IEnumerable<CardsResource>> GetAllAsync()
    {
        var cards= await _cardsService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Cards>, IEnumerable<CardsResource>>(cards);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveCardsResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var cards = _mapper.Map<SaveCardsResource, Cards>(resource);
        var result = await _cardsService.SaveAsync(cards);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var cardsResource = _mapper.Map<Cards, CardsResource>(result.Resource);

        return Created(nameof(PostAsync), cardsResource);

    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCardsResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var category = _mapper.Map<SaveCardsResource, Cards>(resource);
        var result = await _cardsService.UpdateAsync(id, category);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var cardsResource = _mapper.Map<Cards, CardsResource>(result.Resource);

        return Ok(cardsResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _cardsService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var cardsResource = _mapper.Map<Cards, CardsResource>(result.Resource);
        
        return Ok(cardsResource);
    }
}