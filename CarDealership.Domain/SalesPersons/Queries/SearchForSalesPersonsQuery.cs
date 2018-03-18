using System.Collections.Generic;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.SalesPersons.Queries
{
    public class SearchForSalesPersonsQuery : IQuery<List<SalesPerson>>
    {
        public string SearchTerm { get; }

        public SearchForSalesPersonsQuery(string searchTerm)
        {
            SearchTerm = searchTerm;
        }
    }
}