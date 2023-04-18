using Infrastructure;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces;
using Infrastructure.Repositories;
using Core.Specification;
using API.Dtos;
using AutoMapper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;

        private readonly IMapper _mapper;

        public ProductsController(IMapper mapper, IGenericRepository<Product> productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandSpecification();
            var products = await _productRepository.ListAsync(spec);

            return Ok(products.Select(product => new ProductReturnDto
            {
                Id = product.Id,
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Type = product.Type.Name,
                Brand = product.Brand.Name,
                Rating = product.Rating,
                DiscountPercentage = product.DiscountPercentage,
                Thumbnail = product.Thumbnail,
                Stock = product.Stock
            }).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandSpecification(id);
            var product = await _productRepository.GetEntityWithSpec(spec);

            return Ok(_mapper.Map<Product, ProductReturnDto>(product));
        }
    }
}
