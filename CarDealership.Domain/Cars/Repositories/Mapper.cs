using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Repositories
{
    public static class Mapper
    {
        public static Make ToMake(this DomainModels.Make domain)
        {
            var models = domain.Models?
                                .Select(o => o.ToModel())
                                .ToList() ??
                            new List<Model>();

            return new Make
            {
                Id = domain.Id,
                Name = domain.Name,
                Models = models
            };
        }

        public static Model ToModel(this DomainModels.Model domain)
        {
            return new Model
            {
                Id = domain.Id,
                Name = domain.Name
            };
        }

        public static CarPurchase ToCarPurchase(this DomainModels.CarPurchase domain)
        {
            return new CarPurchase
            {
                Id = domain.Id,
                OrderDate = domain.OrderDate,
                PricePaid = domain.PricePaid,
                Car = domain.Car.ToCar(),
                Customer = domain.Customer.ToCustomer(),
                SalesPerson = domain.SalesPerson.ToSalesPerson()
            };
        }

        public static Car ToCar(this DomainModels.Car domain)
        {
            return new Car
            {
                Id = domain.Id,
                RecommendPrice = domain.RecommendPrice,
                Make = domain.MakeAndModel.Make.Name,
                Model = domain.MakeAndModel.Name,
                Extras = domain.Extras.Split(";")
            };
        }

        public static Customer ToCustomer(this DomainModels.Customer domain)
        {
            return new Customer
            {
                Id = domain.Id,
                Name = domain.Name,
                Address = domain.Address,
                Age = domain.Age,
                Created = domain.Created,
                Surname = domain.Surname
            };
        }

        public static SalesPerson ToSalesPerson(this DomainModels.SalesPerson domain)
        {
            return new SalesPerson
            {
                Id = domain.Id,
                Address = domain.Address,
                Name = domain.Name,
                Salary = domain.Salary,
                JobTitle = domain.JobTitle.Title
            };
        }
    }
}