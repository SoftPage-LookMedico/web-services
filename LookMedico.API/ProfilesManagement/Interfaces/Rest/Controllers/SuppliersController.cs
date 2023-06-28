using System.Net.Mime;
using AutoMapper;
using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Services;
using LookMedico.API.ProfilesManagement.Resources;
using LookMedico.API.Shared.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.ProfilesManagement.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SuppliersController: ControllerBase
{
    private readonly ISupplierService _supplierService;
    private readonly IMapper _mapper;

    public SuppliersController(ISupplierService supplierService, IMapper mapper)
    {
        _supplierService = supplierService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SupplierResource>), 200)]

    public async Task<IEnumerable<SupplierResource>> GetAllAsync()
    {
        var suppliers = await _supplierService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Supplier>, IEnumerable<SupplierResource>>(suppliers);
        return resources;
    }

    [HttpGet("{id}")]
    public async Task<SupplierResource> GetById(string id)
    {
        var doctor = await _supplierService.GetByIdAsync(id);
        var resource = _mapper.Map<Supplier, SupplierResource>(doctor);
        return resource;
    }

    
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveSupplierResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);
        var result = await _supplierService.SaveAsync((supplier));

        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);
        return Created(nameof(PostAsync), supplierResource);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(string id, [FromBody] SaveSupplierResource resource)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState.GetErrorMessages());

        var supplier = _mapper.Map<SaveSupplierResource, Supplier>(resource);

        var result = await _supplierService.UpdateAsync(id, supplier);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);
        return Ok(supplierResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(string id)
    {
        var result = await _supplierService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var supplierResource = _mapper.Map<Supplier, SupplierResource>(result.Resource);

        return Ok(supplierResource);
    }
}
