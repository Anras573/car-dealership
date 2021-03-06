﻿using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.CarPurchases.Repositories
{
    public static class Mapper
    {

        public static CarPurchase ToCarPurchase(this DomainModels.CarPurchase domain)
        {
            return new CarPurchase
            {
                Id = domain.Id,
                Car = domain.Car.ToCar(),
                OrderDate = domain.OrderDate,
                PricePaid = domain.PricePaid,
                Customer = domain.Customer.ToCustomer(),
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

        public static Customer ToCustomer(this DomainModels.Customer domain)
        {
            return new Customer
            {
                Id = domain.Id,
                Name = domain.Name,
                Surname = domain.Surname,
                Address = domain.Address,
                Age = domain.Age,
                Created = domain.Created
            };
        }

        public static SalesPerson ToSalesPerson(this DomainModels.SalesPerson domain)
        {
            return new SalesPerson
            {
                Id = domain.Id,
                Name = domain.Name,
                JobTitle = domain.JobTitle.Title,
                Address = domain.Address,
                Salary = domain.Salary,
            };
        }
    }
}