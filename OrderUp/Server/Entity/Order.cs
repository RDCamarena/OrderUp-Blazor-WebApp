namespace OrderUp.Server.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
