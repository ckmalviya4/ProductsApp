﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductsApi.Data;

#nullable disable

namespace ProductsApi.Migrations
{
    [DbContext(typeof(SqlServerDbContext))]
    [Migration("20240427175957_SeedDat")]
    partial class SeedDat
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProductsApi.Data.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateLastMaint")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("MaxPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal");

                    b.Property<decimal>("MinPrice")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateLastMaint = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Laptop",
                            MaxPrice = 1000m,
                            MinPrice = 100m,
                            Name = "Hp Laptop"
                        },
                        new
                        {
                            Id = 2,
                            DateLastMaint = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Mobile",
                            MaxPrice = 1000m,
                            MinPrice = 100m,
                            Name = "Mobile phone"
                        });
                });

            modelBuilder.Entity("ProductsApi.Data.User", b =>
                {
                    b.Property<int>("UserNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserNumber"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("UserNumber");

                    b.HasAlternateKey("UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserNumber = 1,
                            Email = "john.adams@abc.com",
                            FirstName = "John",
                            LastName = "Adams",
                            Password = "Password1",
                            UserName = "jadams"
                        },
                        new
                        {
                            UserNumber = 2,
                            Email = "bob.kerry@abc.com",
                            FirstName = "Bob",
                            LastName = "Kerry",
                            Password = "Password1",
                            UserName = "bob"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
