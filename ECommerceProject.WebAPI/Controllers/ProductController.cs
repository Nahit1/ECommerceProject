using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Core.Entities;
using ECommerceProject.Core.Interfaces;
using ECommerceProject.Core.Specifications;
using ECommerceProject.WebAPI.DTOs;
using ECommerceProject.WebAPI.Errors;
using ECommerceProject.WebAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceProject.WebAPI.Controllers
{
    
    public class ProductController : BaseApiController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _mapper = mapper;
            _productService = productService;
        }
        
        [HttpGet]
        public async Task<ActionResult> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductAndCategorySpec(productParams);

            var countSpec = new ProductWithFiltersForCountSpecification(productParams);

            var totalItems = await _productService.CountAsync(countSpec);

            var products = await _productService.GetProductsAsync(productParams);

            if (products.Count > 0)
            {
                var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductDto>>(products); 
                return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
            }
            else
            {
                return NotFound(new ApiResponse(404,"Product is not found!!"));
            }
            
        }
    }
}