using System;
using System.Collections.Generic;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Queries
{
    public class GetCarPurchasesByModelQuery : IQuery<List<CarPurchase>>
    {
        public Guid ModelId { get; }

        public GetCarPurchasesByModelQuery(Guid modelId)
        {
            ModelId = modelId;
        }
    }
}