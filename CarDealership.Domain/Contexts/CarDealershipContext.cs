using CarDealership.Domain.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.Contexts
{
    public class CarDealershipContext : DbContext
    {
        public CarDealershipContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<CarPurchase> CarPurchases { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Make> Makes { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<SalesPerson> SalesPersons { get; set; } 
    }
}