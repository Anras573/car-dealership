using System.Collections.Generic;
using CarDealership.Domain.Cars.Queries;
using CarDealership.Domain.Cars.Repositories;
using CarDealership.Domain.Framework.QueryHandlers;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.QueryHandlers
{
    public class CarQueryHandler : IQueryHandler<GetAllMakesQuery, List<Make>>,
        IQueryHandler<GetMakeQuery, Make>
    {
        private readonly IMakeRepository _makeRepository;

        public CarQueryHandler(IMakeRepository makeRepository)
        {
            _makeRepository = makeRepository;
        }

        public List<Make> Handle(GetAllMakesQuery query)
        {
            return _makeRepository.GetAll();
        }

        public Make Handle(GetMakeQuery query)
        {
            return _makeRepository.GetById(query.Id);
        }
    }
}