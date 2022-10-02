using OrderUp.Models.Dtos;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components;

namespace OrderUp.Client.Services.Contracts
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpclient;
        private readonly NavigationManager _navigationManager;

        public List<ProductDto> Products { get; set; } = new List<ProductDto>();

        public ProductService(HttpClient httpclient, NavigationManager navigationManager)
        {
            _httpclient = httpclient;
            _navigationManager = navigationManager;
        }



        public async Task CreateProduct(ProductDto product)
        {
            var result = await _httpclient.PostAsJsonAsync("api/product", product);
            await SetProducts();
        }

       
        public async Task DeleteProduct(int id)
        {
            var result = await _httpclient.DeleteAsync($"api/product/{id}");
            await SetProducts();
        }
        public async Task UpdateProduct(ProductDto product)
        {
            var result = await _httpclient.PutAsJsonAsync($"api/product/{product.Id}", product);
            await SetProducts();
        }
        private async Task SetProducts()
        {
            await GetProductList();
            _navigationManager.NavigateTo("products");
        }
        public async Task GetProductList()
        {
            try
            {
                var result = await _httpclient.GetFromJsonAsync<List<ProductDto>>("api/Product");
                if (result != null)
                {
                    Products = result;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

       

        public async Task<ProductDto> GetSingleProduct(int id)
        {

            var result = await _httpclient.GetFromJsonAsync<ProductDto>($"api/Product/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("Product Not Found!");




        }
    }
}
