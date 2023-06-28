﻿namespace LookMedico.API.StoreInventoryManagement.Domain.Models;

public class ProductTag
{
    // Relationships
    
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int TagId { get; set; }
    public Tag Tag { get; set; }
}