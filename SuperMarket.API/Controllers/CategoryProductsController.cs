using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Resources;

namespace SuperMarket.API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/api/categories/{categoryId}/products")]
    public class CategoryProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CategoryProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProductResource>> GetAllByCategoryIdAsync(int categoryId)
        {
            var products = await _productService.ListByCategoryIdAsync(categoryId);
            var resources = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
            return resources;
        }
    }
}