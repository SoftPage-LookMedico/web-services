using System.Net.Mime;
using AutoMapper;
using LookMedico.API.Shared.Extensions;
using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Services;
using LookMedico.API.Sales_Payment_Management.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace LookMedico.API.Sales_Payment_Management.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class ShoppingCartsController: ControllerBase
{
    private readonly IShoppingCartService _shoppingCartService;
    private readonly IMapper _mapper;

    public ShoppingCartsController(IShoppingCartService shoppingCartService, IMapper mapper)
    {
        _shoppingCartService = shoppingCartService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ShoppingCartResource>), 200)]
    public async Task<IEnumerable<ShoppingCartResource>> GetAllAsync()
    {
        var shoppingCarts = await _shoppingCartService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ShoppingCart>, IEnumerable<ShoppingCartResource>>(shoppingCarts);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveShoppingCartResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var shoppingCart = _mapper.Map<SaveShoppingCartResource, ShoppingCart>(resource);
        var result = await _shoppingCartService.SaveAsync(shoppingCart);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);

        return Created(nameof(PostAsync), shoppingCartResource);

    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveShoppingCartResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var shoppingCart = _mapper.Map<SaveShoppingCartResource, ShoppingCart>(resource);
        var result = await _shoppingCartService.UpdateAsync(id, shoppingCart);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);

        return Ok(shoppingCartResource);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _shoppingCartService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var shoppingCartResource = _mapper.Map<ShoppingCart, ShoppingCartResource>(result.Resource);
        
        return Ok(shoppingCartResource);
    }
}