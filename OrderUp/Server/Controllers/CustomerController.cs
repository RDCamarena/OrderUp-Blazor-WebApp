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

                if (customers == null)
                {
                    return NotFound();
                }
                return Ok(customers);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retriving data from the database");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDto>> GetSingleCustomer(int? id)
        {
            var customer = await _dbContext.Customers.FirstOrDefaultAsync(p => p.Id == id);

            if (customer == null)
            {
                return NotFound("Sorry,product not found...");
            }
            return Ok(customer);
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> CreateProduct(CustomerDto customer)
        {
            _dbContext.Customers.Add(new Customer
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
            });
            await _dbContext.SaveChangesAsync();
            return Ok(customer);

        }
    }
}
