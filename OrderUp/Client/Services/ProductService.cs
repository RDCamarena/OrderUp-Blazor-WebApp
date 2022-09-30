using OrderUp.Models.Dtos;
using System.Net.Http.Json;

namespace OrderUp.Client.Services.Contracts
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpclient;

        public ProductService(HttpClient httpclient)
        {
            _httpclient = httpclient;
        }

        public async Task<IEnumerable<ProductDto>> GetProductList()
        {
            try
            {
                var products = await _httpclient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Product");
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
