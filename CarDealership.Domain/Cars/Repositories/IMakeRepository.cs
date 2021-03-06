﻿using System;
using System.Collections.Generic;
using CarDealership.Domain.Framework.Repositories;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Repositories
{
    public interface IMakeRepository : IQueryRepository<Make>
    {
        List<CarPurchase> GetCarPurchasesByMake(Guid makeId);
    }
}