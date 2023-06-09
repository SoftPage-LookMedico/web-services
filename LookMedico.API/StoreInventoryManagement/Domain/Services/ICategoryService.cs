﻿using LookMedico.API.StoreInventoryManagement.Domain.Models;
using LookMedico.API.StoreInventoryManagement.Domain.Services.Communication;

namespace LookMedico.API.Store_Inventory_Management.Domain.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> ListAsync();
    Task<CategoryResponse> SaveAsync(Category category);
    Task<CategoryResponse> UpdateAsync(int id, Category category);
    Task<CategoryResponse> DeleteAsync(int id);
}