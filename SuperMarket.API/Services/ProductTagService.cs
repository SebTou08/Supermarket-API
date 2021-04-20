using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Repositories;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Services
{
    public class ProductTagService : IProductTagServices
    {
        private readonly IProductTagRepository _productTagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductTagService(IProductTagRepository productTagRepository, IUnitOfWork unitOfWork)
        {
            _productTagRepository = productTagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ProductTag>> ListAsync()
        {
            return await _productTagRepository.ListAsync();
        }

        public async Task<ICollection<ProductTag>> ListByProductIdAsync(int productId)
        {
            return (ICollection<ProductTag>) await _productTagRepository.ListByProductId(productId);
        }

        public async Task<IEnumerable<ProductTag>> ListByTagAsync(int tagId)
        {
            return await _productTagRepository.ListByTagId(tagId);
        }

        public async Task<ProductTagResponse> AssingProductTagAsync(int ptoductId, int tagId)
        {
            try
            {
                await _productTagRepository.AssingProductTag(ptoductId, tagId);
                await _unitOfWork.CompleteAsync();
                ProductTag productTag = await _productTagRepository.FindByProductIdAndTagId(ptoductId, tagId);
                return new ProductTagResponse(productTag);
            }
            catch (Exception e)
            {
                return new ProductTagResponse($"An error ocurred while assinging Tag to Product: {e.Message}");
            }
        }

        public async Task<ProductTagResponse> UnassingProductTagAsync(int productId, int tagId)
        {
            try
            {                
                ProductTag productTag = await _productTagRepository.FindByProductIdAndTagId(productId, tagId);
                 _productTagRepository.remove(productTag);
                await _unitOfWork.CompleteAsync();
                return new ProductTagResponse(productTag);
            }
            catch (Exception e)
            {
                return new ProductTagResponse($"An error ocurred while unassinging Tag to Product: {e.Message}");
            }
        }
    }
}