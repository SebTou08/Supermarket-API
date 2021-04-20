﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Resources;
using AutoMapper;
using SuperMarket.API.Extensions;

namespace SuperMarket.API.Controllers
{
    [Route("/api/[controller]")]
    [Produces("appliction/json")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CategoryResource>),200)]
        public async Task<IEnumerable<CategoryResource>> GetAllAsync()
        {
            var categories = await _categoryService.ListAsync();
            var resources = _mapper.Map<IEnumerable<Category>, IEnumerable<CategoryResource>>(categories);
            return resources;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CategoryResource),200)]
        [ProducesResponseType(typeof(BadRequestResult),404)]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _categoryService.GetByIdASync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.SaveAsync(category);

            if (!result.Succes)
                return BadRequest(result.Message);

            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] SaveCategoryResource resource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var category = _mapper.Map<SaveCategoryResource, Category>(resource);
            var result = await _categoryService.UpdateAsync(id, category);

            if (!result.Succes)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
            
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            if (!result.Succes)
                return BadRequest(result.Message);
            var categoryResource = _mapper.Map<Category, CategoryResource>(result.Resource);
            return Ok(categoryResource);
            
        }
       
    }
}