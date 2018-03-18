using System.Collections.Generic;
using CarDealership.Domain.ReadModels;
using CarDealership.Domain.Framework.Repositories;

namespace CarDealership.Domain.SalesPersons.Repositories
{
    public interface ISalesPersonRepository : IQueryRepository<SalesPerson>
    {
        List<SalesPerson> GetSalesPersonsByQuery(string query);
    }
}