using System.Collections.Generic;
using System.Linq;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Repositories
{
    public static class Mapper
    {
        public static Make ToMake(this DomainModels.Make domain)
        {
            var models = domain.Models?
                                .Select(o => o.ToModel())
                                .ToList() ??
                            new List<Model>();

            return new Make
            {
                Id = domain.Id,
                Name = domain.Name,
                Models = models
            };
        }

        public static Model ToModel(this DomainModels.Model domain)
        {
            return new Model
            {
                Id = domain.Id,
                Name = domain.Name
            };
        }
    }
}