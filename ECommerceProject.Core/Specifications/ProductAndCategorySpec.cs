using System;
using System.Linq.Expressions;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Core.Specifications
{
    public class ProductAndCategorySpec:BaseSpecification<Product>
    {
        public ProductAndCategorySpec(int? categoryId) : base(x=>(!categoryId.HasValue || x.CategoryId==categoryId))
        {
            AddInclude(x=>x.Category);
        }
        
        // public ProductAndCategorySpec(int id) 
        //     : base(x => x.Id == id)
        // {
        //     AddInclude(x => x.Category);
        // }
    }
}