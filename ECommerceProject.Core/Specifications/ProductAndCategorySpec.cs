using System;
using System.Linq.Expressions;
using ECommerceProject.Core.Entities;

namespace ECommerceProject.Core.Specifications
{
    public class ProductAndCategorySpec:BaseSpecification<Product>
    {
        public ProductAndCategorySpec(ProductSpecParams productParams) : base(x=>
            (string.IsNullOrEmpty(productParams.Search) || x.Name.ToLower().Contains(productParams.Search)) &&
            (!productParams.CategoryId.HasValue || x.CategoryId==productParams.CategoryId))
        {
            AddInclude(x=>x.Category);
            AddOrderBy(x=>x.Name);
            ApplyPaging(productParams.PageSize * (productParams.PageIndex - 1), productParams.PageSize);
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(x=>x.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(x=>x.Price);
                        break;
                    default:
                        AddOrderBy(x=>x.Name);
                        break;
                }
            }
        }
        
        // public ProductAndCategorySpec(int id) 
        //     : base(x => x.Id == id)
        // {
        //     AddInclude(x => x.Category);
        // }
    }
    
    
}