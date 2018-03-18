using System.Collections.Generic;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Customers.Queries
{
    public class SearchForCustomersQuery : IQuery<List<Customer>>
    {
        public string SearchTerm { get; }

        public SearchForCustomersQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}