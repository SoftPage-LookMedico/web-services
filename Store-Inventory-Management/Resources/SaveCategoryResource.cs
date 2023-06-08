using System.ComponentModel.DataAnnotations;

namespace LookMedico.API.Store_Inventory_Management.Resources;

public class SaveCategoryResource
{
    [Required]
    public string Name { get; set; }
}