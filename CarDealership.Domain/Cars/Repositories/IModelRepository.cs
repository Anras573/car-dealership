using System;
using System.Collections.Generic;
using CarDealership.Domain.Framework.Repositories;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Repositories
{
    public interface IModelRepository : IQueryRepository<Model>
    {
        List<CarPurchase> GetCarPurchasesByModel(Guid modelId);
    }
}