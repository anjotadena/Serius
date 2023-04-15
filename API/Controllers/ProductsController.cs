using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string GetProducts()
        {
            return "Get all products";
        }

        [HttpGet("{id}")]
        public string GetProduct(int id)
        {
            return $"Get product by ID: {id}";
        }
    }
}
