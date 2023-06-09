using System.ComponentModel.DataAnnotations;

namespace LookMedico.API.Payment.Resources;

public class SaveCardsResource
{
    [Required]
    public string Name { get; set; }
}