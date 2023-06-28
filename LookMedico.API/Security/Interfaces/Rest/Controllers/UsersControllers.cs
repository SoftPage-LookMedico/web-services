using System.Net.Mime;
using AutoMapper;
using LookMedico.API.Security.Domain.Models;
using LookMedico.API.Security.Domain.Services;
using LookMedico.API.Security.Domain.Services.Communication;
using LookMedico.API.Security.Resources;
using LookMedico.API.Shared.Extensions;

using Microsoft.AspNetCore.Mvc;

namespace LookMedico.API.Security.Interfaces.Rest.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public UsersController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.ListAsync();
        var resources = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(users);
        return Ok(resources);
    }
    
    [HttpGet("{id}")]
    public async Task<UserResource> GetById(string id)
    {
        var doctor = await _userService.GetByIdAsync(id);
        var resource = _mapper.Map<User, UserResource>(doctor);
        return resource;
    }
    
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AuthenticateRequest resource)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState.GetErrorMessages());
        }

        var user = _mapper.Map<AuthenticateRequest, User>(resource);
        var result = await _userService.SaveAsync((user));

        if (!result.Success)
        {
            return BadRequest(result.Message);
        }

        var userResource = _mapper.Map<User, UserResource>(result.Resource);

        return Created(nameof(PostAsync), userResource);


    }
}
