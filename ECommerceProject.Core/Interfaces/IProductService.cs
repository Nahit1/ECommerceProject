using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceProject.Core.Entities;
using ECommerceProject.Core.Specifications;

namespace ECommerceProject.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(ProductSpecParams specParams);
        Task<int> CountAsync(ISpecification<Product> spec);
        
    }
}