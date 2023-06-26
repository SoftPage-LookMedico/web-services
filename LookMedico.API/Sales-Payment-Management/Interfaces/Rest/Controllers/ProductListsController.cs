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

public class ProductListsController: ControllerBase
{
    private readonly IProductListService _productListService;
    private readonly IMapper _mapper;

    public ProductListsController(IProductListService productListService, IMapper mapper)
    {
        _productListService = productListService;
        _mapper = mapper;
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<ProductListResource>), 200)]
    public async Task<IEnumerable<ProductListResource>> GetAllAsync()
    {
        var productLists = await _productListService.ListAsync();
        var resources = _mapper.Map<IEnumerable<ProductList>, IEnumerable<ProductListResource>>(productLists);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductListResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var productList = _mapper.Map<SaveProductListResource, ProductList>(resource);
        var result = await _productListService.SaveAsync(productList);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var productListResource = _mapper.Map<ProductList, ProductListResource>(result.Resource);

        return Created(nameof(PostAsync), productListResource);

    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductListResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var productList = _mapper.Map<SaveProductListResource, ProductList>(resource);
        var result = await _productListService.UpdateAsync(id, productList);

        if (!result.Success)
            return BadRequest(result.Message);
        
        var productListResource = _mapper.Map<ProductList, ProductListResource>(result.Resource);

        return Ok(productListResource);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _productListService.DeleteAsync(id);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var productListResource = _mapper.Map<ProductList, ProductListResource>(result.Resource);
        
        return Ok(productListResource);
    }
}