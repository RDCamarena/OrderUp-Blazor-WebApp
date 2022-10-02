using Microsoft.AspNetCore.Components;
using OrderUp.Models.Dtos;
using System.Net.Http.Json;

namespace OrderUp.Client.Services.Contracts
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpclient;
        private readonly NavigationManager _navigationManager;

        public List<CustomerDto> Customers { get; set; } = new List<CustomerDto>();

        public CustomerService(HttpClient httpclient, NavigationManager navigationManager)
        {
            _httpclient = httpclient;
            _navigationManager = navigationManager;
        }

        public async Task GetCustomerObj()
        {
            try
            {
                var result = await _httpclient.GetFromJsonAsync<List<CustomerDto>>("api/Customer");
                if (result != null)
                {
                    Customers = result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CustomerDto> GetSingleCustomer(int id)
        {
            var result = await _httpclient.GetFromJsonAsync<CustomerDto>($"api/Customer/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Product Not Found!");


        }

        public async Task CreateCustomer(CustomerDto customer)
        {
            var result = await _httpclient.PostAsJsonAsync("api/customer", customer);
            await GetCustomerObj();
            _navigationManager.NavigateTo("/");
        }
    }
}
