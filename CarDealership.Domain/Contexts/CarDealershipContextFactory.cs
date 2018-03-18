using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarDealership.Domain.Contexts
{
    public class CarDealershipContextFactory : IDesignTimeDbContextFactory<CarDealershipContext>
    {
        public CarDealershipContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealershipContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarDealership;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new CarDealershipContext(optionsBuilder.Options);
        }
    }
}