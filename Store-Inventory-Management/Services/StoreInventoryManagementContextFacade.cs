using LookMedico.API.Store_Inventory_Management.Interfaces.Internal;

namespace LookMedico.API.Store_Inventory_Management.Services;

public class StoreInventoryManagementContextFacade : IStoreInventoryManagementContextFacade
{
    private readonly CategoryService _categoryService;
    private readonly ProductService _productService;
    
    public int TotalProducts()
    {
        return _productService.ListAsync().Result.Count();
    }

    public int TotalCategories()
    {
        return _categoryService.ListAsync().Result.Count();
    }
}