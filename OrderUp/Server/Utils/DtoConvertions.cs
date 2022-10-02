using OrderUp.Models.Dtos;
using OrderUp.Server.Entity;

namespace OrderUp.Server.Utils
{
    public static class DtoConvertions
    {
        public static IEnumerable<OrderDto> ConvertToDto( this IEnumerable<Order> orders, IEnumerable<Product> products)
        {
            return( from order in orders
                    join product in products
                    on order.ProductId equals product.Id
                    select new OrderDto
                    {
                        Id = order.Id,
                        Date = order.Date,
                        Quantity = order.Quantity,
                        Product = product.ProductName,
                        ProductId = product.Id,
                        ProductDescript = product.Description,
                        TotalPrice = (int) product.Price * order.Quantity,
                        CustomerId = order.CustomerId,

                    }).ToList();
        }
    }
}
