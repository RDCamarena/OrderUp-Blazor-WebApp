using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models.Dtos;
using OrderUp.Server.Data;


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
    }
}
