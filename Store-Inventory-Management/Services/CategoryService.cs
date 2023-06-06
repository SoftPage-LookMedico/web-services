﻿using LookMedico.API.Shared.Domain.Repositories;
using LookMedico.API.Store_Inventory_Management.Domain.Models;
using LookMedico.API.Store_Inventory_Management.Domain.Repositories;
using LookMedico.API.Store_Inventory_Management.Domain.Services;
using LookMedico.API.Store_Inventory_Management.Domain.Services.Communication;

namespace LookMedico.API.Store_Inventory_Management.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
    {
        _categoryRepository = categoryRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Category>> ListAsync()
    {
        return await _categoryRepository.ListAsync();
    }

    public async Task<CategoryResponse> SaveAsync(Category category)
    {
        try
        {
            await _categoryRepository.AddAsync(category);
            await _unitOfWork.CompleteAsync();

            return new CategoryResponse(category);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public async Task<CategoryResponse> UpdateAsync(int id, Category category)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);
        
        if (existingCategory == null)
            return new CategoryResponse("Category not found.");
        
        existingCategory.Name = category.Name;

        try
        {
            _categoryRepository.Update(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<CategoryResponse> DeleteAsync(int id)
    {
        var existingCategory = await _categoryRepository.FindByIdAsync(id);
        
        if (existingCategory == null)
            return new CategoryResponse("Category not found.");

        try
        {
            _categoryRepository.Remove(existingCategory);
            await _unitOfWork.CompleteAsync();

            return new CategoryResponse(existingCategory);
        }
        catch (Exception e)
        {
            return new CategoryResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}