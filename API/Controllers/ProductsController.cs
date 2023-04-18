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
        public async Task<ActionResult<IReadOnlyList<ProductReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithTypesAndBrandSpecification();
            var products = await _productRepository.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnDto>>(products));
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
