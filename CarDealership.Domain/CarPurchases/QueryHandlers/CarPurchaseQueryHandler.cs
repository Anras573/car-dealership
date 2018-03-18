using System.Collections.Generic;
using CarDealership.Domain.CarPurchases.Queries;
using CarDealership.Domain.CarPurchases.Repositories;
using CarDealership.Domain.Framework.QueryHandlers;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Domain.CarPurchases.QueryHandlers
{
    public class CarPurchaseQueryHandler : IQueryHandler<GetAllCarPurchasesQuery, List<CarPurchase>>,
        IQueryHandler<SearchForCarPurchasesQuery, List<CarPurchase>>,
        IQueryHandler<GetCarPurchaseQuery, CarPurchase>
    {
        private readonly ICarPurchasesRepository _repository;

        public CarPurchaseQueryHandler(ICarPurchasesRepository repository)
        {
            _repository = repository;
        }

        public List<CarPurchase> Handle(GetAllCarPurchasesQuery query)
        {
            return _repository.GetAll();
        }

        public List<CarPurchase> Handle(SearchForCarPurchasesQuery query)
        {
            return _repository.FindAllBetweenDates(query.StartDate, query.EndDate);
        }

        public CarPurchase Handle(GetCarPurchaseQuery query)
        {
            return _repository.GetById(query.Id);
        }
    }
}