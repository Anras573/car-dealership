using System.Collections.Generic;
using CarDealership.Domain.Framework.QueryHandlers;
using CarDealership.Domain.ReadModels;
using CarDealership.Domain.SalesPersons.Queries;
using CarDealership.Domain.SalesPersons.Repositories;

namespace CarDealership.Domain.SalesPersons.QueryHandler
{
    public class SalesPersonHandler : IQueryHandler<GetAllSalesPersonsQuery, List<SalesPerson>>,
        IQueryHandler<GetSalesPersonQuery, SalesPerson>,
        IQueryHandler<SearchForSalesPersonsQuery, List<SalesPerson>>
    {
        private readonly ISalesPersonRepository _repository;

        public SalesPersonHandler(ISalesPersonRepository repository)
        {
            _repository = repository;
        }

        public List<SalesPerson> Handle(GetAllSalesPersonsQuery query)
        {
            return _repository.GetAll();
        }

        public SalesPerson Handle(GetSalesPersonQuery query)
        {
            return _repository.GetById(query.Id);
        }

        public List<SalesPerson> Handle(SearchForSalesPersonsQuery query)
        {
            return _repository.GetSalesPersonsByQuery(query.SearchTerm);
        }
    }
}