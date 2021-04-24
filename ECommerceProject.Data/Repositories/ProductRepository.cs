using ECommerceProject.Core.Entities;
using ECommerceProject.Core.Interfaces;

namespace ECommerceProject.Data.Repositories
{
    public class ProductRepository:GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ECommerceContext context) : base(context)
        {
        }
    }
}