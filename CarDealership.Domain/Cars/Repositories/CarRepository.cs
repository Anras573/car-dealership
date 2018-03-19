using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.Framework.Repositories;
using CarDealership.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.Cars.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarDealershipContext _context;

        public CarRepository(CarDealershipContext context)
        {
            _context = context;
        }
    }
}