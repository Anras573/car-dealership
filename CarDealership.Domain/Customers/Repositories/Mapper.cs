using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Customers.Repositories
{
    public static class Mapper
    {
        public static Customer ToCustomer(this DomainModels.Customer domain)
        {
            var purchases = domain.CarPurchases?
                                .Select(o => o.ToCarPurchase())
                                .ToList() ??
                            new List<CarPurchase>();

            return new Customer
            {
                Id = domain.Id,
                Address = domain.Address,
                CarPurchases = purchases,
                Age = domain.Age,
                Created = domain.Created,
                Name = domain.Name,
                Surname = domain.Surname
            };
        }

        public static CarPurchase ToCarPurchase(this DomainModels.CarPurchase domain)
        {
            return new CarPurchase
            {
                Id = domain.Id,
                Car = domain.Car.ToCar(),
                OrderDate = domain.OrderDate,
                PricePaid = domain.PricePaid,
                SalesPerson = domain.SalesPerson.ToSalesPerson()
            };
        }

        public static Car ToCar(this DomainModels.Car domain)
        {
            return new Car
            {
                Id = domain.Id,
                Make = domain.MakeAndModel.Make.Name,
                Model = domain.MakeAndModel.Name,
                Extras = domain.Extras.Split(";"),
                RecommendPrice = domain.RecommendPrice
            };
        }

        public static SalesPerson ToSalesPerson(this DomainModels.SalesPerson domain)
        {
            return new SalesPerson
            {
                Id = domain.Id,
                Name = domain.Name,
                Address = domain.Address,
                JobTitle = domain.JobTitle.Title,
                Salary = domain.Salary
            };
        }
    }
}