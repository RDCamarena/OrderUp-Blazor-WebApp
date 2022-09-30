using Microsoft.EntityFrameworkCore;
using OrderUp.Server.Entity;

namespace OrderUp.Server.Data
{
    public class OrderUpDbContext : DbContext
    {
        public OrderUpDbContext(DbContextOptions<OrderUpDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Customer creation into database
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                FirstName = "Cameron",
                LastName = "Dunlap",
                Email = "enim.etiam@yahoo.net",
                PhoneNumber = "202-918-2132"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 2,
                FirstName = "Cameran",
                LastName = "Mercer",
                Email = "nulla.integer@aol.couk",
                PhoneNumber = "929-891-3348"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 3,
                FirstName = "Arthur",
                LastName = "Hernandez",
                Email = "nec@protonmail.edu",
                PhoneNumber = "212-241-0523"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 4,
                FirstName = "Isadora",
                LastName = "Philips",
                Email = "a.auctor.non@aol.couk",
                PhoneNumber = "326-314-3918"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 5,
                FirstName = "Davis",
                LastName = "Vega",
                Email = "odio.auctor@protonmail.ca",
                PhoneNumber = "582-333-0008"
            });


            //Product creating into database
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                ProductName = "Macbook Pro 13",
                Price = 1299.99,
                Description = "Brand new Macbook Pro with new retna display, a 3tb memory and carrying a solid 4060 nvidia graphic card."

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 2,
                ProductName = "Tv 4K",
                Price = 570.65,
                Description = "Gorgeous 60inch TV with 4k capabilities."
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 3,
                ProductName = "RTX 4090",
                Price = 2500.00,
                Description = "The most powerful graphic card in the market... good luck getting it."
            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 4,
                ProductName = "Culinary 50 Piece Set",
                Price = 399.99,
                Description = "Start your chef dream with a fully loaded cooking set."
            });


            //Creation of orders for the database
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 1,
                Date = "2022-03-01",
                CustomerId = 4,
                ProductId = 2,
                Quantity = 5
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 2,
                Date = "2022-01-20",
                CustomerId = 2,
                ProductId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 3,
                Date = "2019-12-01",
                ProductId = 3,
                Quantity = 10
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 4,
                Date = "2012-05-19",
                CustomerId = 5,
                ProductId = 4,
                Quantity = 1
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 5,
                Date = "2022-09-30",
                CustomerId = 4,
                ProductId = 3,
                Quantity = 1
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 6,
                Date = "2022-03-10",
                CustomerId = 3,
                ProductId = 1,
                Quantity = 1
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 7,
                Date = "2022-03-10",
                CustomerId = 3,
                ProductId = 2,
                Quantity = 3
            });
            modelBuilder.Entity<Order>().HasData(new Order
            {
                Id = 8,
                Date = "2005-11-01",
                CustomerId = 1,
                ProductId = 1,
                Quantity = 2
            });


        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}

