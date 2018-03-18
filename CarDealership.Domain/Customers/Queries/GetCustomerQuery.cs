using System;
using CarDealership.Domain.ReadModels;
using CarDealership.Domain.Framework.Queries;

namespace CarDealership.Domain.Customers.Queries
{
    public class GetCustomerQuery : IQuery<Customer>
    {
        public Guid Id { get; }

        public GetCustomerQuery(Guid id)
        {
            Id = id;
        }
    }
}