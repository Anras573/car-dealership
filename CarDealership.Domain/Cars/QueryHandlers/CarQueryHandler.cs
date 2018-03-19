using System.Collections.Generic;
using CarDealership.Domain.Cars.Queries;
using CarDealership.Domain.Cars.Repositories;
using CarDealership.Domain.Framework.QueryHandlers;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.Cars.QueryHandlers
{
    public class CarQueryHandler : IQueryHandler<GetAllMakesQuery, List<Make>>,
        IQueryHandler<GetMakeQuery, Make>,
        IQueryHandler<GetCarPurchasesByMakeQuery, List<CarPurchase>>,
        IQueryHandler<GetModelQuery, Model>,
        IQueryHandler<GetCarPurchasesByModelQuery, List<CarPurchase>>
    {
        private readonly IMakeRepository _makeRepository;
        private readonly IModelRepository _modelRepository;

        public CarQueryHandler(IMakeRepository makeRepository, IModelRepository modelRepository)
        {
            _makeRepository = makeRepository;
            _modelRepository = modelRepository;
        }

        public List<Make> Handle(GetAllMakesQuery query)
        {
            return _makeRepository.GetAll();
        }

        public Make Handle(GetMakeQuery query)
        {
            return _makeRepository.GetById(query.Id);
        }

        public List<CarPurchase> Handle(GetCarPurchasesByMakeQuery query)
        {
            return _makeRepository.GetCarPurchasesByMake(query.MakeId);
        }

        public Model Handle(GetModelQuery query)
        {
            return _modelRepository.GetById(query.ModelId);
        }

        public List<CarPurchase> Handle(GetCarPurchasesByModelQuery query)
        {
            return _modelRepository.GetCarPurchasesByModel(query.ModelId);
        }
    }
}