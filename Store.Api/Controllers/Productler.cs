using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Infrastructure.Data;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Productler(StoreContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var products = await context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var product = await context.Products.FindAsync(id);
            return Ok(product);
        }
    }
}
