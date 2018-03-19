using System;
using System.Collections.Generic;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Queries
{
    public class GetCarPurchasesByMakeQuery : IQuery<List<CarPurchase>>
    {
        public Guid MakeId { get; }

        public GetCarPurchasesByMakeQuery(Guid makeId)
        {
            MakeId = makeId;
        }
    }
}