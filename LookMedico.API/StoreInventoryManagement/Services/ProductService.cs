using LookMedico.API.Shared.Domain.Repositories;
using LookMedico.API.Store_Inventory_Management.Domain.Repositories;
using LookMedico.API.Store_Inventory_Management.Domain.Services;
using LookMedico.API.StoreInventoryManagement.Domain.Models;
using LookMedico.API.StoreInventoryManagement.Domain.Repositories;
using LookMedico.API.StoreInventoryManagement.Domain.Services.Communication;

namespace LookMedico.API.Store_Inventory_Management.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICategoryRepository _categoryRepository;

    public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _unitOfWork = unitOfWork;
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _productRepository.ListAsync();
    }

    public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
    {
        return await _productRepository.FindByCategoryAsync(categoryId);
    }

    public async Task<ProductResponse> SaveAsync(Product product)
    {
        // Validate existence of assigned category

        var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);

        if (existingCategory == null)
            return new ProductResponse("Invalid category.");
        
        // Perform adding
        
        try
        {
            await _productRepository.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            
            return new ProductResponse(product);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new ProductResponse($"An error occurred while saving the tutorial: {e.Message}");
        }
    }

    public async Task<ProductResponse> UpdateAsync(int productId, Product product)
    {
        // Validate if products exists

        var existingProduct = await _productRepository.FindByIdAsync(productId);

        if (existingProduct == null)
            return new ProductResponse("Tutorial not found.");
        
        // Validate existence of assigned category
        
        var existingCategory = await _categoryRepository.FindByIdAsync(product.CategoryId);
        
        if (existingCategory == null)
            return new ProductResponse("Invalid category.");
        
        // Validate if Title is already used
        
        var existingProductWithTitle = await _productRepository.FindByTitleAsync(product.Title);
        
        if (existingProductWithTitle != null && existingProductWithTitle.Id != productId)
            return new ProductResponse("Title is already used.");
        
        // Modify fields
        
        existingProduct.Title = product.Title;
        existingProduct.Description = product.Description;
        
        // Perform update
        
        try
        {
            _productRepository.Update(existingProduct);
            await _unitOfWork.CompleteAsync();
            
            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            // Error handling
            return new ProductResponse($"An error occurred while updating the productl: {e.Message}");
        }
    }

    public async Task<ProductResponse> DeleteAsync(int productId)
    {
        // Validate if products exists
        
        var existingProduct = await _productRepository.FindByIdAsync(productId);
        
        if (existingProduct == null)
            return new ProductResponse("Product not found.");
        
        // Perform delete
        
        try
        {
            _productRepository.Remove(existingProduct);
            await _unitOfWork.CompleteAsync();
            
            return new ProductResponse(existingProduct);
        }
        catch (Exception e)
        {
            // Error handling
            return new ProductResponse($"An error occurred while deleting the product: {e.Message}");
        }
    }
}