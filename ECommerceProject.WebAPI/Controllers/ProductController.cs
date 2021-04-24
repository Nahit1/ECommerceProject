using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ECommerceProject.Core.Entities;
using ECommerceProject.Core.Interfaces;
using ECommerceProject.Core.Specifications;
using ECommerceProject.WebAPI.DTOs;
using ECommerceProject.WebAPI.Errors;
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
        public async Task<ActionResult> GetProducts(int? categoyId)
        {
            var products = await _productService.GetProductsAsync(categoyId);

            if (products.Count > 0)
            {
                return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductDto>>(products));
            }
            else
            {
                return NotFound(new ApiResponse(404,"Product is not found!!"));
            }
            
        }
    }
}