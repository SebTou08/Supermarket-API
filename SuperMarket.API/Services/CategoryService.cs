using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Repositories;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Domain.Services.Communications;

namespace SuperMarket.API.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Category>> ListAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryResponse> GetByIdASync(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error ocurred while saving the caterogy: {e.Message}");
            }
        }

        public Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryResponse> DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}