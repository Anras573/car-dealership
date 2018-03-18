using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.CarPurchases.Repositories
{
    public class CarPurchaseRepository : ICarPurchasesRepository
    {
        private readonly CarDealershipContext _context;

        public CarPurchaseRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public List<CarPurchase> GetAll()
        {
            return _context.CarPurchases
                .OrderBy(o => o.OrderDate)
                .Include(o => o.SalesPerson)
                .ThenInclude(o => o.JobTitle)
                .Include(o => o.Car)
                .ThenInclude(o => o.MakeAndModel)
                .ThenInclude(o => o.Make)
                .Include(o => o.Customer)
                .Select(o => o.ToCarPurchase())
                .ToList();
        }

        public CarPurchase GetById(Guid id)
        {
            return _context.CarPurchases
                .Where(o => o.Id == id)
                .Include(o => o.SalesPerson)
                .ThenInclude(o => o.JobTitle)
                .Include(o => o.Car)
                .ThenInclude(o => o.MakeAndModel)
                .ThenInclude(o => o.Make)
                .Include(o => o.Customer)
                .First()
                .ToCarPurchase();
        }

        public List<CarPurchase> FindAllBetweenDates(DateTime startDate, DateTime endDate)
        {
            return _context.CarPurchases
                .Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate)
                .OrderBy(o => o.OrderDate)
                .Include(o => o.SalesPerson)
                .ThenInclude(o => o.JobTitle)
                .Include(o => o.Car)
                .ThenInclude(o => o.MakeAndModel)
                .ThenInclude(o => o.Make)
                .Include(o => o.Customer)
                .Select(o => o.ToCarPurchase())
                .ToList();
        }
    }
}