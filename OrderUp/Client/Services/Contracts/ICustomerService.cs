using OrderUp.Models.Dtos;

namespace OrderUp.Client.Services.Contracts
{
    public interface ICustomerService
    {
        List<CustomerDto> Customers { get; set; }

        Task GetCustomerObj();

        Task CreateCustomer(CustomerDto customer);

        

        Task<CustomerDto> GetSingleCustomer(int id);
    }
}
