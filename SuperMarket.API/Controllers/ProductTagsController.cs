using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.API.Domain.Models;
using SuperMarket.API.Domain.Services;
using SuperMarket.API.Resources;

namespace SuperMarket.API.Controllers
{
    [Microsoft.AspNetCore.Components.Route("/api/products/{productId}/tags")]
    public class ProductTagsController : ControllerBase
    {
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;
        private readonly IProductTagServices _productTagServices;

        public ProductTagsController(ITagService tagService, IMapper mapper, IProductTagServices productTagServices)
        {
            _tagService = tagService;
            _mapper = mapper;
            _productTagServices = productTagServices;
        }

        [HttpGet]
        public async Task<IEnumerable<TagResource>> GetAllByProductIdAsync(int productId)
        {
            var tags = await _tagService.ListByProductIdAsync(productId);
            var resource = _mapper.Map<IEnumerable<Tag>, IEnumerable<TagResource>>(tags);
            return resource;
        }

        [HttpPost("{tagId}")]
        public async Task<IActionResult> AssingProductTag(int productId, int tagId)
        {
            var result = await _productTagServices.AssingProductTagAsync(productId, tagId);
            if (!result.Succes)
                return BadRequest(result.Message);
            var tagResource = _mapper.Map<Tag, TagResource>(result.Resource.Tag);
            return Ok(tagResource);
        }
    }
}