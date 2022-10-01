using OrderUp.Models.Dtos;
using System.Net.Http.Json;

namespace OrderUp.Client.Services.Contracts
{
    public  class OrderService : IOrderService
    {
        private readonly HttpClient _httpclient;

        public OrderService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public  async Task<IEnumerable<OrderDto>> GetOrders()
        {
            try
            {
                var orders = await _httpclient.GetFromJsonAsync<IEnumerable<OrderDto>>("api/Order");
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
