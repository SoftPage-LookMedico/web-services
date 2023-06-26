using AutoMapper;
using LookMedico.API.Shared.Extensions;
using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Services;
using LookMedico.API.Sales_Payment_Management.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.Sales_Payment_Management.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1[controller]")]

public class LocationsController: ControllerBase
{
    private readonly ILocationService _locationService;
    private readonly IMapper _mapper;
    
    public LocationsController(ILocationService locationService, IMapper mapper)
    {
        _locationService = locationService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<LocationResource>> GetAllAsync()
    {
        var locations = await _locationService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Location>, IEnumerable<LocationResource>>(locations);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveLocationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var location = _mapper.Map<SaveLocationResource, Order>(resource);
        
        var result = await _locationService.SaveAsync(order);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var locationResource = _mapper.Map<Order, LocationResource>(result.Resource);

        return Created(nameof(PostAsync), locationResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveLocationResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var location = _mapper.Map<SaveLocationResource, Location>(resource);
        var result = await _locationService.UpdateAsync(id, location);

        if (!result.Success)
            return BadRequest(result.Message);

        var locationResource = _mapper.Map<Location, LocationResource>(result.Resource);
        return Ok(locationResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _locationService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var locationResource = _mapper.Map<Location, LocationResource>(result.Resource);
        return Ok(locationResource);
    }
}