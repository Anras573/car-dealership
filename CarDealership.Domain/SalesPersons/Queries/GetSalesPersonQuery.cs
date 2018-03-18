using System;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.SalesPersons.Queries
{
    public class GetSalesPersonQuery : IQuery<SalesPerson>
    {
        public Guid Id { get; }

        public GetSalesPersonQuery(Guid id)
        {
            Id = id;
        }
    }
}