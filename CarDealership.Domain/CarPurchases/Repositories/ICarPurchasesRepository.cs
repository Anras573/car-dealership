using System;
using System.Collections.Generic;
using CarDealership.Domain.Framework.Repositories;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.CarPurchases.Repositories
{
    public interface ICarPurchasesRepository : IQueryRepository<CarPurchase>
    {
        List<CarPurchase> FindAllBetweenDates(DateTime startDate, DateTime endDate);
    }
}