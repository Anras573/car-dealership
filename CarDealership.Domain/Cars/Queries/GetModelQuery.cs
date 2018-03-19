using System;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Queries
{
    public class GetModelQuery : IQuery<Model>
    {
        public Guid ModelId { get; }

        public GetModelQuery(Guid modelId)
        {
            ModelId = modelId;
        }
    }
}