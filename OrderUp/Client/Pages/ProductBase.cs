using Microsoft.AspNetCore.Components;
using OrderUp.Client.Services.Contracts;
using OrderUp.Models.Dtos;

namespace OrderUp.Client.Pages
{
    public class ProductBase : ComponentBase
    {
        [Inject]
        public IProductService ProductService { get; set; }

        public IEnumerable<ProductDto> Products { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Products = await ProductService.GetProductList();
        }
    }
}
