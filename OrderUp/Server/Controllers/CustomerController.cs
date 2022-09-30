using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models.Dtos;
using OrderUp.Server.Data;


namespace OrderUp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly OrderUpDbContext _dbContext;

        public CustomerController(OrderUpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            try
            {
                var customers = await _dbContext.Customers.ToListAsync();

                if(customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error retriving data from the database" );
            }
        }
    }
}
