using System;
using System.Collections.Generic;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.CarPurchases.Queries
{
    public class SearchForCarPurchasesQuery : IQuery<List<CarPurchase>>
    {
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }

        public SearchForCarPurchasesQuery(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}