using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderUp.Models.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
