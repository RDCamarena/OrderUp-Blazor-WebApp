using OrderUp.Models.Dtos;

namespace OrderUp.Client.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductList();
    }
}
