using Microsoft.AspNetCore.Components;
using OrderUp.Client.Services.Contracts;
using OrderUp.Models.Dtos;

namespace OrderUp.Client.Pages
{
    public class CustomerBase : ComponentBase
    {
        [Inject]
        public ICustomerService CustomerService { get; set; }

        public IEnumerable<CustomerDto> Customers { get; set; }


        protected override async Task OnInitializedAsync()
        {
            Customers = await CustomerService.GetCustomerObj();
        }
    }
}
