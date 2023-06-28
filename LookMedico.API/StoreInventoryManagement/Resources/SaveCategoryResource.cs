using System.ComponentModel.DataAnnotations;

namespace LookMedico.API.StoreInventoryManagement.Resources;

public class SaveCategoryResource
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    [Required]
    public string PhotoUrl { get; set; }
}