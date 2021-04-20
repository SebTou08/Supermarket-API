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

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> GetByIdASync(int id)
        {
            var existingCategory = await _categoryRepository.FindById(id);
            if (existingCategory == null)
                return new CategoryResponse("Category not found");
            return new CategoryResponse(existingCategory);
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

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindById(id);
            if (existingCategory == null)
                return new CategoryResponse("Category not found");
            existingCategory.Name = category.Name;
            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error ocurred while finding the category {e.Message}");
            }
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindById(id);
            if (existingCategory == null)
                return new CategoryResponse("Category not found");
            
            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new CategoryResponse($"An error ocurred while finding the category {e.Message}");
            }
        }
    }
}