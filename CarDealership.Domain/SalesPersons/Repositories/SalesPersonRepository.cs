using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.SalesPersons.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private readonly CarDealershipContext _context;

        public SalesPersonRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public List<SalesPerson> GetAll()
        {
            return _context.SalesPersons
                .OrderBy(o => o.JobTitle.Title)
                .Include(o => o.JobTitle)
                .Select(o => o.ToSalesPerson())
                .ToList();
        }

        public SalesPerson GetById(Guid id)
        {
            return _context.SalesPersons
                .Where(o => o.Id == id)
                .Include(o => o.Sales)
                .ThenInclude(o => o.Car)
                .ThenInclude(o => o.MakeAndModel)
                .ThenInclude(o => o.Make)
                .Include(o => o.Sales)
                .ThenInclude(o => o.Customer)
                .Include(o => o.JobTitle)
                .First()
                .ToSalesPerson();
        }

        public List<SalesPerson> GetSalesPersonsByQuery(string query)
        {
            return _context.SalesPersons
                .Where(o => o.Name.Contains(query) || o.Address.Contains(query))
                .OrderBy(o => o.JobTitle.Title)
                .Include(o => o.JobTitle)
                .Select(o => o.ToSalesPerson())
                .ToList();
        }
    }
}