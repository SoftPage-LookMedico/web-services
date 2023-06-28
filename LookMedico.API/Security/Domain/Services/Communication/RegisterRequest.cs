using System.ComponentModel.DataAnnotations;

namespace LookMedico.API.Security.Domain.Services.Communication;

public class RegisterRequest
{
    [Required] public string Id { get; set; }
    [Required] public string Password { get; set; }
}