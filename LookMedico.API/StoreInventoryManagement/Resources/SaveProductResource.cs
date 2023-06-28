using System.ComponentModel.DataAnnotations;

namespace LookMedico.API.Store_Inventory_Management.Resources;

public class SaveProductResource
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    
    [MaxLength(120)]
    public string Description { get; set; }
    
    [Required]
    public string PhotoUrl { get; set; }
    
    [Required]
    public string Price { get; set; }
    
    [Required]
    public string InventoryStatus { get; set; }
    
    [Required]
    public int CategoryId { get; set; }
}