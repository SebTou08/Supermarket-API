using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Repositories;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;


        public ProductService(IProductRepository productRepository, IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> ListAsync()
        {
           return await _productRepository.ListAsync();
        }

        public async Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId)
        {
            return await _productRepository.ListByCategoryId(categoryId);
        }

        public async Task<IEnumerable<Product>> ListByTagIdAsync(int tagId)
        {
            var productTags = await _productTagRepository.ListByTagId(tagId);
            var products = productTags.Select(PT => PT.Product).ToList();
            return products;
        }

        public async Task<ProductTagResponse> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}