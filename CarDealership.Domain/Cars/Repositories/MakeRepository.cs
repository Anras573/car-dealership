using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.Cars.Repositories
{
    public class MakeRepository : IMakeRepository
    {
        private readonly CarDealershipContext _context;

        public MakeRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public List<Make> GetAll()
        {
            return _context.Makes
                .OrderBy(o => o.Name)
                .Select(o => o.ToMake())
                .ToList();
        }

        public Make GetById(Guid id)
        {
            return _context.Makes
                .Where(o => o.Id == id)
                .Include(o => o.Models)
                .First()
                .ToMake();
        }

        public List<CarPurchase> GetCarPurchasesByMake(Guid makeId)
        {
            return _context.CarPurchases
                .Where(o => o.Car.MakeAndModel.Make.Id == makeId)
                .OrderBy(o => o.OrderDate)
                .Include(o => o.Car)
                .ThenInclude(o => o.MakeAndModel)
                .ThenInclude(o => o.Make)
                .Include(o => o.Customer)
                .Include(o => o.SalesPerson)
                .ThenInclude(o => o.JobTitle)
                .Select(o => o.ToCarPurchase())
                .ToList();
        }
    }
}