using OrderUp.Models.Dtos;
using System.Net.Http.Json;

namespace OrderUp.Client.Services.Contracts
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpclient;

        public CustomerService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<IEnumerable<CustomerDto>> GetCustomerObj()
        {
            try
            {
                var customers = await _httpclient.GetFromJsonAsync<IEnumerable<CustomerDto>>("api/Customer");
                return customers;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
