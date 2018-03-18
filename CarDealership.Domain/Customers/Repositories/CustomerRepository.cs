using System;
using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.Contexts;
using CarDealership.Domain.ReadModels;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Domain.Customers.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CarDealershipContext _context;

        public CustomerRepository(CarDealershipContext context)
        {
            _context = context;
        }

        public List<Customer> GetAll()
        {
            return _context.Customers
                .OrderBy(o => o.Created)
                .Select(o => o.ToCustomer())
                .ToList();
        }

        public Customer GetById(Guid id)
        {
            return _context.Customers
                .Where(o => o.Id == id)
                .Include(o => o.CarPurchases)
                .ThenInclude(o => o.Car)
                .ThenInclude(o => o.MakeAndModel)
                .ThenInclude(o => o.Make)
                .Include(o => o.CarPurchases)
                .ThenInclude(o => o.SalesPerson)
                .ThenInclude(o => o.JobTitle)
                .First()
                .ToCustomer();
        }

        public List<Customer> GetCustomersByQuery(string query)
        {
            return _context.Customers
                .Where(o => o.Name.Contains(query) || o.Surname.Contains(query) || o.Address.Contains(query))
                .OrderBy(o => o.Created)
                .Select(o => o.ToCustomer())
                .ToList();
        }
    }
}