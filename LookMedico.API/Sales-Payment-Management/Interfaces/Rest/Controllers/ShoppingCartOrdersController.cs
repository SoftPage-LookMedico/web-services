using AutoMapper;
using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Services;
using LookMedico.API.Sales_Payment_Management.Resources;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.Sales_Payment_Management.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/shoppingCart/{shoppingCartId}/orders")]

public class ShoppingCartOrdersController : ControllerBase
{
    private readonly IOrderService _orderService;
    private readonly IMapper _mapper;

    public ShoppingCartOrdersController(IOrderService orderService, IMapper mapper)
    {
        _orderService = orderService;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IEnumerable<OrderResource>> GetAllByShoppingCartId(int shoppingCartId)
    {
        var products = await _orderService.ListByShoppingCartIdIdAsync(shoppingCartId);
        var resources = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderResource>>(orders);
        return resources;
    }
}