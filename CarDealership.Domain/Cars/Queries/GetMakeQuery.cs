using System;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.Queries
{
    public class GetMakeQuery : IQuery<Make>
    {
        public Guid Id { get; }

        public GetMakeQuery(Guid id)
        {
            Id = id;
        }
    }
}