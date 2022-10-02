using Microsoft.AspNetCore.Components;
using OrderUp.Client.Services.Contracts;
using OrderUp.Models.Dtos;
using System.Net.Http.Json;

namespace OrderUp.Client.Services.Contracts
{
    public class OrderService : IOrderService
    {
        private readonly HttpClient _httpclient;
        private readonly NavigationManager _navigationManager;

        public List<OrderDto> Orders { get; set; }
        public OrderService(HttpClient httpclient, NavigationManager navigationManager)
        {
            _httpclient = httpclient;
            _navigationManager = navigationManager;
        }
        public async Task GetOrders(int id)
        {
            var orders = await _httpclient.GetFromJsonAsync<List<OrderDto>>($"api/order/{id}");
           Orders = orders;
           
        }

        public async Task GetAllOrders(int id)
        {
                await GetOrders(id);
            _navigationManager.NavigateTo($"/customer/{id}");
        }

        public async Task CreateOrder(OrderInDto order, int id)
        {
            await _httpclient.PostAsJsonAsync("api/order", order);
            await GetAllOrders(id);

        }

        public async Task DeleteOrder(int id, int customerId)
        {
            var result = await _httpclient.DeleteAsync($"api/order/{id}");
            await GetAllOrders(customerId);
        }
    }
}
