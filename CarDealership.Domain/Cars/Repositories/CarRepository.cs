using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.Cars.Repositories
{
    public class CarRepository : IMakeRepository
    {
        private readonly CarDealershipContext _context;

        public CarRepository(CarDealershipContext context)
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
    }
}