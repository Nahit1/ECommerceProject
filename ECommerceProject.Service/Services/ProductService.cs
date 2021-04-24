using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceProject.Core.Entities;
using ECommerceProject.Core.Interfaces;
using ECommerceProject.Core.Specifications;

namespace ECommerceProject.Service.Services
{
    public class ProductService:IProductService
    {
        private readonly IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public Task<Product> GetProductByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        

        public async Task<IReadOnlyList<Product>> GetProductsAsync(int? categoryId)
        {
            var spec = new ProductAndCategorySpec(categoryId);
            var products = await _productRepo.ListAsync(spec);
            return products;
        }
    }
}