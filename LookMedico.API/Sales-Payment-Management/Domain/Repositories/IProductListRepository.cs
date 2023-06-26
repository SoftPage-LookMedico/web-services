using LookMedico.API.Sales_Payment_Management.Domain.Models;

namespace LookMedico.API.Sales_Payment_Management.Domain.Repositories;

public interface IProductListRepository
{
    Task<IEnumerable<ProductList>> ListAsync();
    Task AddAsync(ProductList productList);
    Task<ProductList> FindByIdAsync(int id);
    void Update(ProductList productList);
    void Remove(ProductList productList);
}