using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ProductsApi.Data
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public SqlServerDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .Property(x => x.MaxPrice)
                .HasColumnType("decimal")
                .HasPrecision(18, 4);
            modelBuilder.Entity<Product>()
             .Property(x => x.MinPrice)
             .HasColumnType("decimal")
             .HasPrecision(18, 4);
            modelBuilder.Entity<Product>()
                .Property(x => x.DateLastMaint)
                .HasDefaultValueSql("getutcdate()");

            modelBuilder.Entity<User>()
                .HasAlternateKey(x => x.UserName);

            SeedData(modelBuilder);
        }


        private ModelBuilder SeedData(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(new Product[] {
                new Product{
                    Id = 1,
                    Name = "Hp Laptop",
                    Description = "Laptop",
                    MaxPrice = 1000,
                    MinPrice = 100
                },
                new Product{
                    Id = 2,
                    Name = "Mobile phone",
                    Description = "Mobile",
                    MaxPrice = 1000,
                    MinPrice = 100
                }
            });

            modelBuilder.Entity<User>().HasData(new User[] {
                new User{
                 FirstName = "John",
                 LastName = "Adams",
                 UserName = "jadams",
                 Password = "Password1",
                 Email = "john.adams@abc.com",
                 UserNumber = 1

                },
                new User{
                   FirstName = "Bob",
                 LastName = "Kerry",
                 UserName = "bob",
                 Password = "Password1",
                 Email = "bob.kerry@abc.com",
                UserNumber = 2}
            });
            return modelBuilder;
        }
    }
}
