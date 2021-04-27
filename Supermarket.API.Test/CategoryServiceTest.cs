using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Persistence.Repositories;
using SuperMarket.API.Domain.Services.Communications;
using SuperMarket.API.Services;

namespace Supermarket.API.Test
{
    public class CategoryServiceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAllAsyncWhenNoCategoriesReturnsEmptyColletion()
        {
            //!Arange
            var mockCategoryRepository = GetDefaultICategoryRepositoryInstace();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            
            mockCategoryRepository.Setup(r => r.ListAsync()).ReturnsAsync(new List<Category>());
            
            var service = new CategoryService(mockCategoryRepository.Object, mockUnitOfWork.Object);
            //!Act
            
            List<Category> result = (List<Category>) await service.ListAsync();
            var categoriesCount = result.Count;
            //!Assert
            categoriesCount.Should().Equals(0);
        }

        [Test]
        public async Task GetByIdAsuyncWhenInvalidReturnsCategoryNotFoundResponse()
        {
            //!Arrange
            var mockCategoryRepository = GetDefaultICategoryRepositoryInstace();
            var mockUnitOfWork = GetDefaultIUnitOfWorkInstance();
            var categoryId = 5;
            //Category category = new Category();
            mockCategoryRepository.Setup(r => r.FindById(categoryId)).Returns(Task.FromResult<Category>(null));
            var service = new CategoryService(mockCategoryRepository.Object, mockUnitOfWork.Object);

            //!Act
            CategoryResponse result = await service.GetByIdASync(categoryId);
            var message = result.Message;

            //!Assert
            message.Should().Be("Category not found");
        }

        
        
        
        
        
        private Mock<ICategoryRepository> GetDefaultICategoryRepositoryInstace()
        {
            return new Mock<ICategoryRepository>();
        }

        private Mock<IUnitOfWork> GetDefaultIUnitOfWorkInstance()
        {
            return new Mock<IUnitOfWork>();
        }
    }
}