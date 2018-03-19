using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.Cars.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private readonly CarDealershipContext _context;

        public ModelRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public List<Model> GetAll()
        {
            throw new NotImplementedException();
        }

        public Model GetById(Guid id)
        {
            return _context.Models
                .Find(id)
                .ToModel();
        }

        public List<CarPurchase> GetCarPurchasesByModel(Guid modelId)
        {
            return _context.CarPurchases
                .Where(o => o.Car.MakeAndModel.Id == modelId)
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