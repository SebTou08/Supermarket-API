using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Repositories;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork, IProductTagRepository productTagRepository)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
            _productTagRepository = productTagRepository;
        }

        private readonly IProductTagRepository _productTagRepository;
        public async Task<IEnumerable<Tag>> ListAsync()
        {
            return await _tagRepository.ListAsync();
        }

        public async Task<IEnumerable<Tag>> ListByProductIdAsync(int productId)
        {
            var productTgas = await _productTagRepository.ListByProductId(productId);
            var tags = productTgas.Select(pt => pt.Tag).ToList();
            return tags;
        }

        public async Task<TagResponse> GetById(int id)
        {
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("Tag not found");
            return new TagResponse(existingTag);
        }

        public async Task<TagResponse> SaveAsync(Tag tag)
        {
            try
            {
                await _tagRepository.AddAsync(tag);
                await _unitOfWork.CompleteAsync();
                return new TagResponse(tag);
            }
            catch (Exception e)
            {
                return new TagResponse($"An error ocurred while saving the tag {e.Message}");
            }
        }

        public async Task<TagResponse> UpdateAsync(int id, Tag tag)
        {
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
                return new TagResponse("Tag not found");
            existingTag.Name = tag.Name;
            try
            {
                _tagRepository.Update(existingTag);
                await _unitOfWork.CompleteAsync();
                return new TagResponse(existingTag);
            }
            catch (Exception e)
            {
                return new TagResponse($"An error ocurred while saving the tag {e.Message}");
            }
        }

        public async Task<TagResponse> DeleteAsync(int id)
        {
            var existingTag = await _tagRepository.FindById(id);
            if (existingTag == null)
            {
                return new TagResponse("Tag not found");
            }

            try
            {
                _tagRepository.Remove(existingTag);
                await _unitOfWork.CompleteAsync();
                return new TagResponse(existingTag);
            }
            catch (Exception e)
            {
                return new TagResponse($"An error occured while deleting tag: {e.Message}");
            }
        }
    }
}