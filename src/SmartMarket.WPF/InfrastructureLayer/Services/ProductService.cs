using Microsoft.EntityFrameworkCore;
using SmartMarket.WPF.ApplicationLayer.Abstractions;
using SmartMarket.WPF.ApplicationLayer.Exceptions;
using SmartMarket.WPF.DomainLayer.Entities;
using SmartMarket.WPF.infrastructureLayer.Persistence.AppDbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartMarket.WPF.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _context;

        public ProductService()
        {
            _context = new ApplicationDbContext();
        }
        public async Task AddProductAsync(Product product)
        {
            if (await _context.Products.AnyAsync(x => x.Name == product.Name && x.ProductCode == product.ProductCode))
            {
                throw new ProductAlreadyExistException();
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.ToListAsync();

            if (products == null)
            {
                throw new ProductNotFoundException();
            }

            return products;
        }


        public async Task<Product> GetProductByCodeAsync(string productCode)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.ProductCode == productCode);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            return product;
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == name);

            if (product == null)
            {
                throw new ProductNotFoundException();
            }

            return product;
        }

        public async Task UpdateProductAsync(string productCode, Product product)
        {
            var sourceProduct = await _context.Products.FirstOrDefaultAsync(x => x.ProductCode == productCode);

            if (sourceProduct == null)
            {
                throw new ProductNotFoundException();
            }

            sourceProduct.Name = product.Name ?? sourceProduct.Name;
            if (product.Price == 0)
            {
                sourceProduct.Price = product.Price;
            }
            sourceProduct.ProductCode = product.ProductCode;
            sourceProduct.TotalAmount += product.TotalAmount;
            sourceProduct.ProductCode = product.ProductCode ?? sourceProduct.ProductCode;

            _context.Products.Update(sourceProduct);
            await _context.SaveChangesAsync();
        }
    }
}
