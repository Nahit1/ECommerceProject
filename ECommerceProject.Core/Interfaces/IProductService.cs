using System.Collections.Generic;
using System.Threading.Tasks;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Core.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(int? categoryId);
    }
}