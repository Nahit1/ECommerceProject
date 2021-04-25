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

        

        public async Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams specParams)
        {
            var spec = new ProductAndCategorySpec(specParams);
            var products = await _productRepo.ListAsync(spec);
            return products;
        }

        public async Task<int> CountAsync(ISpecification<Product> spec)
        {
            return await _productRepo.CountAsync(spec);
        }
    }
}