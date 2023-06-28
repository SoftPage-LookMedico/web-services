using AutoMapper;
using LookMedico.API.Store_Inventory_Management.Domain.Services;
using LookMedico.API.Store_Inventory_Management.Resources;
using LookMedico.API.StoreInventoryManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.Store_Inventory_Management.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/categories/{categoryId}/products")]
public class CategoryProductsController : ControllerBase
{
    private readonly IProductService _productService;
    private readonly IMapper _mapper;

    public CategoryProductsController(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<ProductResource>> GetAllByCategoryId(int categoryId)
    {
        var products = await _productService.ListByCategoryIdAsync(categoryId);
        var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        return resources;
    }
}