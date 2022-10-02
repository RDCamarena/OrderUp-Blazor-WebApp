using OrderUp.Models.Dtos;

namespace OrderUp.Client.Services.Contracts
{
    public interface IOrderService
    {
        List<OrderDto> Orders {get; set;}
        Task GetOrders(int id);

        Task GetAllOrders(int id);
        Task CreateOrder(OrderInDto order, int id);

        Task DeleteOrder(int id, int customerId);
    }
}
