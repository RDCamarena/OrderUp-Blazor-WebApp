using OrderUp.Models.Dtos;

namespace OrderUp.Client.Services.Contracts
{
    public  interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrders();
    }
}
