using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models.Dtos;
using OrderUp.Server.Data;

namespace OrderUp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderUpDbContext _dbContext;

        public OrderController(OrderUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders()
        {
            try
            {
                var orders = await _dbContext.Orders.ToListAsync();

                if (orders == null)
                {
                    return NotFound();
                }
                return Ok(orders);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }
    }
}
