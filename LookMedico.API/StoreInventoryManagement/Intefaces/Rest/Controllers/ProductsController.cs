﻿using AutoMapper;
using LookMedico.API.Shared.Extensions;
using LookMedico.API.Store_Inventory_Management.Domain.Services;
using LookMedico.API.Store_Inventory_Management.Resources;
using LookMedico.API.StoreInventoryManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.Store_Inventory_Management.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductsController: ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public ProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllAsync()
    {
        var products = await _productService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var product = _mapper.Map<SaveProductResource, Product>(resource);
        
        var result = await _productService.SaveAsync(product);
        
        if (!result.Success)
            return BadRequest(result.Message);
        
        var tutorialResource = _mapper.Map<Product, ProductResource>(result.Resource);

        return Created(nameof(PostAsync), tutorialResource);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody] SaveProductResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var tutorial = _mapper.Map<SaveProductResource, Product>(resource);
        var result = await _productService.UpdateAsync(id, tutorial);

        if (!result.Success)
            return BadRequest(result.Message);

        var tutorialResource = _mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(tutorialResource);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _productService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var tutorialResource = _mapper.Map<Product, ProductResource>(result.Resource);
        return Ok(tutorialResource);
    }
}