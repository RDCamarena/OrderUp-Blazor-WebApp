using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderUp.Models.Dtos;
using OrderUp.Server.Data;
using OrderUp.Server.Entity;
using OrderUp.Server.Utils;

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


        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<OrderDto>>> GetOrders(int id)
        {

            var orders = await _dbContext.Orders.ToListAsync();
            var products = await _dbContext.Products.ToListAsync();

            if (orders == null || products == null)
            {
                return NotFound();
            }
            else
            {
                var orderDtos = orders.ConvertToDto(products);

                var orderList = orderDtos.Where(ol => ol.CustomerId == id).ToList();
                return Ok(orderList);
            }



        }


        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(OrderInDto order)
        {
            _dbContext.Orders.Add(new Order
            {
                CustomerId = order.CustomerId,
                Id = order.Id,
                Date = order.Date,
                ProductId = order.ProductId,
                Quantity = order.Quantity,
            });
            await _dbContext.SaveChangesAsync();
            return Ok(await GetFreshOrder(order.CustomerId));

        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<OrderDto>>> GetAllOrders()
        {

            var orders = await _dbContext.Orders.ToListAsync();
            return Ok(orders);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<List<OrderDto>>> DeleteOrder(int id)
        {
            var dbOrder = _dbContext.Orders.FirstOrDefault(o => o.Id == id);
            if (dbOrder == null) { return NotFound(); }
            _dbContext.Orders.Remove(dbOrder);
            await _dbContext.SaveChangesAsync();
            return Ok(await GetFreshOrder(id));

        }

        private async Task<ActionResult<List<OrderDto>>> GetFreshOrder(int id)
        {
            var orderList = await GetOrders(id);

            if (orderList == null) { return NotFound(); }
            return Ok(orderList);

        }

    }
}
