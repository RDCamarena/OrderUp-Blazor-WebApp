using OrderUp.Models.Dtos;

namespace OrderUp.Client.Services.Contracts
{
    public interface IProductService
    {
        List<ProductDto> Products { get; set; }
        Task GetProductList();

        Task UpdateProduct(ProductDto product);
        Task DeleteProduct(int id);

        Task CreateProduct(ProductDto product);

        Task<ProductDto> GetSingleProduct(int id);  
    }
}
