using OrderUp.Models.Dtos;

namespace OrderUp.Client.Services.Contracts
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetCustomerObj();
    }
}
