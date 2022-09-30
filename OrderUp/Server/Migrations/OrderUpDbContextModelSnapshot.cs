﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OrderUp.Server.Data;

#nullable disable

namespace OrderUp.Server.Migrations
{
    [DbContext(typeof(OrderUpDbContext))]
    partial class OrderUpDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OrderUp.Server.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "enim.etiam@yahoo.net",
                            FirstName = "Cameron",
                            LastName = "Dunlap",
                            PhoneNumber = "202-918-2132"
                        },
                        new
                        {
                            Id = 2,
                            Email = "nulla.integer@aol.couk",
                            FirstName = "Cameran",
                            LastName = "Mercer",
                            PhoneNumber = "929-891-3348"
                        },
                        new
                        {
                            Id = 3,
                            Email = "nec@protonmail.edu",
                            FirstName = "Arthur",
                            LastName = "Hernandez",
                            PhoneNumber = "212-241-0523"
                        },
                        new
                        {
                            Id = 4,
                            Email = "a.auctor.non@aol.couk",
                            FirstName = "Isadora",
                            LastName = "Philips",
                            PhoneNumber = "326-314-3918"
                        },
                        new
                        {
                            Id = 5,
                            Email = "odio.auctor@protonmail.ca",
                            FirstName = "Davis",
                            LastName = "Vega",
                            PhoneNumber = "582-333-0008"
                        });
                });

            modelBuilder.Entity("OrderUp.Server.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 4,
                            Date = "2022-03-01",
                            ProductId = 2,
                            Quantity = 5
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Date = "2022-01-20",
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 0,
                            Date = "2019-12-01",
                            ProductId = 3,
                            Quantity = 10
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 5,
                            Date = "2012-05-19",
                            ProductId = 4,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 4,
                            Date = "2022-09-30",
                            ProductId = 3,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 6,
                            CustomerId = 3,
                            Date = "2022-03-10",
                            ProductId = 1,
                            Quantity = 1
                        },
                        new
                        {
                            Id = 7,
                            CustomerId = 3,
                            Date = "2022-03-10",
                            ProductId = 2,
                            Quantity = 3
                        },
                        new
                        {
                            Id = 8,
                            CustomerId = 1,
                            Date = "2005-11-01",
                            ProductId = 1,
                            Quantity = 2
                        });
                });

            modelBuilder.Entity("OrderUp.Server.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Brand new Macbook Pro with new retna display, a 3tb memory and carrying a solid 4060 nvidia graphic card.",
                            Price = 1299.99,
                            ProductName = "Macbook Pro 13"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Gorgeous 60inch TV with 4k capabilities.",
                            Price = 570.64999999999998,
                            ProductName = "Tv 4K"
                        },
                        new
                        {
                            Id = 3,
                            Description = "The most powerful graphic card in the market... good luck getting it.",
                            Price = 2500.0,
                            ProductName = "RTX 4090"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Start your chef dream with a fully loaded cooking set.",
                            Price = 399.99000000000001,
                            ProductName = "Culinary 50 Piece Set"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}