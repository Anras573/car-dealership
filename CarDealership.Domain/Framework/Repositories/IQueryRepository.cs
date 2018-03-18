using System;
using System.Collections.Generic;

namespace CarDealership.Domain.Framework.Repositories
{
    public interface IQueryRepository<T> : IRepository
    {
        List<T> GetAll();
        T GetById(Guid id);
    }
}