using System;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.CarPurchases.Queries
{
    public class GetCarPurchaseQuery : IQuery<CarPurchase>
    {
        public Guid Id { get; }

        public GetCarPurchaseQuery(Guid id)
        {
            Id = id;
        }
    }
}