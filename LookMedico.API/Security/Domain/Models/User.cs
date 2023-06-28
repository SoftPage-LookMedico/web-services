using System.Text.Json.Serialization;

namespace LookMedico.API.Security.Domain.Models;

public class User
{
    public string Id { get; set; }

    public string Password { get; set; }
}
