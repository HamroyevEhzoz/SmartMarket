using SmartMarket.WPF.DomainLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMarket.WPF.ApplicationLayer.Abstractions
{
    public interface IProductService
    {
        Task AddProductAsync(Product product);
        Task<Product> GetProductByCodeAsync(string productCode);
        Task<Product> GetProductByNameAsync(string name);
        Task<List<Product>> GetAllProductsAsync();
        Task UpdateProductAsync(string productCode, Product product);
    }
}
