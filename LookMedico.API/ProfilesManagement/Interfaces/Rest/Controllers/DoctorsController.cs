using System.Net.Mime;
using AutoMapper;
using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Domain.Services;
using LookMedico.API.ProfilesManagement.Resources;
using LookMedico.API.Shared.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.ProfilesManagement.Interfaces.Rest.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]

public class DoctorsController: ControllerBase
{
    private readonly IDoctorService _doctorService;
    private readonly IMapper _mapper;

    public DoctorsController(IDoctorService doctorService, IMapper mapper)
    {
        _doctorService = doctorService;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DoctorResource>), 200)]

    public async Task<IEnumerable<DoctorResource>> GetAllAsync()
    {
        var doctors = await _doctorService.ListAsync();
        var resources = _mapper.Map<IEnumerable<Doctor>, IEnumerable<DoctorResource>>(doctors);
        return resources;
    }
    
    [HttpGet("{id}")]

    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] SaveDoctorResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var doctor = _mapper.Map<SaveDoctorResource, Doctor>(resource);
        var result = await _doctorService.SaveAsync((doctor));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);

        return Created(nameof(PostAsync), doctorResource);


    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(string id, [FromBody] SaveDoctorResource resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var doctor = _mapper.Map<SaveDoctorResource, Doctor>(resource);

        var result = await _doctorService.UpdateAsync(id, doctor);

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);

        return Ok(doctorResource);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteASync(string id)
    {
        var result = await _doctorService.DeleteAsync(id);

        if (!result.Success)
            return BadRequest(result.Message);

        var doctorResource = _mapper.Map<Doctor, DoctorResource>(result.Resource);

        return Ok(doctorResource);
    }


}
