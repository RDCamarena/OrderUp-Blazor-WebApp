using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models.Dtos;
using OrderUp.Server.Data;
using OrderUp.Server.Entity;

namespace OrderUp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly OrderUpDbContext _dbContext;

        public ProductController(OrderUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(ProductDto product)
        {
            _dbContext.Products.Add(new Product
            {
                Id = product.Id,
                Price = product.Price,
                ProductName = product.ProductName,
                Description = product.Description,
            });
            await _dbContext.SaveChangesAsync();
            return Ok(product);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> UpdateProduct(ProductDto product, int id)
        {
            var dbProduct = await _dbContext.Products.FirstOrDefaultAsync(up => up.Id == id);
            if (dbProduct == null)
            {
                return NotFound("Sorry no product was found");
            }

            dbProduct.Price = product.Price;
            dbProduct.ProductName = product.ProductName;
            dbProduct.Description = product.Description;

            await _dbContext.SaveChangesAsync();
            return Ok(await GetDbProducts());
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> DeleteProduct(int id)
        {
            var dbProduct = _dbContext.Products.FirstOrDefault(up => up.Id == id);
            if (dbProduct == null) { return NotFound("Sorry it doesn't exist"); }

            _dbContext.Products.Remove(dbProduct);
            await _dbContext.SaveChangesAsync();
            return (await GetDbProducts());
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetProducts()
        {
            try
            {
                var products = await _dbContext.Products.ToListAsync();

                if (products == null)
                {
                    return NotFound();
                }
                return Ok(products);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetSingleProduct(int? id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound("Sorry,product not found...");
            }
            return Ok(product);
        }

        public async Task<ActionResult<IEnumerable<ProductDto>>> GetDbProducts()
        {

            var products = await _dbContext.Products.ToListAsync();

            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }

    }
}


        

       


