using System.Collections.Generic;
using CarDealership.Domain.ReadModels;
using CarDealership.Domain.Framework.Repositories;

namespace CarDealership.Domain.Customers.Repositories
{
    public interface ICustomerRepository : IQueryRepository<Customer>
    {
        List<Customer> GetCustomersByQuery(string query);
    }
}