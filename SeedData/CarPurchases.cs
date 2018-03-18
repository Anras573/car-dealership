using System;
using System.Collections.Generic;
using CarDealership.Domain.DomainModels;

namespace SeedData
{
    public static class CarPurchases
    {
        public static List<CarPurchase> GetCarPurchaseses(List<Customer> customers, List<Car> cars, List<SalesPerson> salesPersons)
        {
            var carPurchases = new List<CarPurchase>();

            foreach (var customer in customers)
            {
                var car = cars[Util.Random.Next(cars.Count)];
                var purchase = new CarPurchase
                {
                    Id = Guid.NewGuid(),
                    Customer = customer,
                    OrderDate = customer.Created,
                    SalesPerson = salesPersons[Util.Random.Next(salesPersons.Count)],
                    Car = car,
                    PricePaid = Util.Random.Next((int)(car.RecommendPrice * 0.8m), (int) car.RecommendPrice)
                };
                carPurchases.Add(purchase);
            }

            // We select 10 random customers who will buy another car.
            for (var i = 0; i < 10; i++)
            {
                var customer = customers[Util.Random.Next(customers.Count)];
                var car = cars[Util.Random.Next(cars.Count)];
                var purchase = new CarPurchase
                {
                    Id = Guid.NewGuid(),
                    Customer = customer,
                    OrderDate = Util.RandomDate(customer.Created),
                    SalesPerson = salesPersons[Util.Random.Next(salesPersons.Count)],
                    Car = car,
                    PricePaid = Util.Random.Next((int)(car.RecommendPrice * 0.8m), (int)car.RecommendPrice)
                };
                carPurchases.Add(purchase);
            }

            return carPurchases;
        }
    }
}