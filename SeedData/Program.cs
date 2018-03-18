using System;
using System.Linq;
using CarDealership.Domain.Contexts;
using Microsoft.EntityFrameworkCore;

namespace SeedData
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarDealershipContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=CarDealership;Trusted_Connection=True;MultipleActiveResultSets=true");
            var context = new CarDealershipContext(optionsBuilder.Options);
            context.Database.Migrate();

            if (!context.Customers.Any())
            {
                Console.WriteLine("Seeding database with customers...");
                var customers = Customers.Get();
                context.Customers.AddRange(customers);
                context.SaveChanges();
                Console.WriteLine("Done seeding customers.");
            }

            if (!context.Makes.Any())
            {
                Console.WriteLine("Seeding database with makes and models...");
                var makes = Cars.GetMakes();
                context.Makes.AddRange(makes);
                context.SaveChanges();
                Console.WriteLine("Done seeding makes and models.");
            }

            if (!context.Cars.Any())
            {
                Console.WriteLine("Seeding database with cars...");
                var models = context.Models.ToList();
                var cars = Cars.GetCars(models);
                context.Cars.AddRange(cars);
                context.SaveChanges();
                Console.WriteLine("Done seeding cars.");
            }

            if (!context.SalesPersons.Any())
            {
                Console.WriteLine("Seeding database with sales persons...");
                var jobTitles = SalesPersons.JobTitlesWithSalesPersons();
                context.JobTitles.AddRange(jobTitles);
                context.SaveChanges();
                Console.WriteLine("Done seeding sales persons.");
            }

            if (!context.CarPurchases.Any())
            {
                Console.WriteLine("Seeding database with car purchases...");
                var customers = context.Customers.ToList();
                var cars = context.Cars.ToList();
                var salespersons = context.SalesPersons.ToList();
                var purchases = CarPurchases.GetCarPurchaseses(customers, cars, salespersons);
                context.CarPurchases.AddRange(purchases);
                context.SaveChanges();
                Console.WriteLine("Done seeding car purchases.");
            }

            Console.WriteLine("Done seeding the database...");
            Console.ReadLine();
        }
    }
}
