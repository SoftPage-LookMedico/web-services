using System.ComponentModel.DataAnnotations;

namespace LookMedico.API.ProfilesManagement.Resources;

public class SaveSupplierResource
{
    [Required]
    [MaxLength(30)]
    public string Id { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string BusinessName { get; set; }

    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    [MinLength(9)]
    [MaxLength(9)]
    public string Phone { get; set; }
}
