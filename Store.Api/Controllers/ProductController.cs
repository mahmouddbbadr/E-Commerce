using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Core.Entities;
using Store.Core.IRepository;
using Store.Core.Specification;
using Store.Infrastructure.Data;

namespace Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IGenericRepository<Product> productRepo, IGenericRepository<ProductBrand> brandRepo,
       IGenericRepository<ProductType> typeRepo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var spec = new ProductsWithTypesAndBrandsSpecification();
            return Ok(await productRepo.GetAllWithSpecification(spec));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            return Ok(await productRepo.GetEntityWithSpecification(spec)); 
        }

        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> getProductBrands()
        {
            return Ok(await brandRepo.GetAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<List<ProductBrand>>> getProductTypes()
        {
            return Ok(await typeRepo.GetAllAsync());
        }
    }
}
