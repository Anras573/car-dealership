using System.Collections.Generic;
using CarDealership.Domain.Customers.Queries;
using CarDealership.Domain.Customers.Repositories;
using CarDealership.Domain.ReadModels;
using CarDealership.Domain.Framework.QueryHandlers;

namespace CarDealership.Domain.Customers.QueryHandlers
{
    public class CustomerQueryHandler : IQueryHandler<GetAllCustomersQuery, List<Customer>>,
        IQueryHandler<GetCustomerQuery, Customer>,
        IQueryHandler<SearchForCustomersQuery, List<Customer>>
    {
        private readonly ICustomerRepository _repository;

        public CustomerQueryHandler(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public List<Customer> Handle(GetAllCustomersQuery query)
        {
            return _repository.GetAll();
        }

        public Customer Handle(GetCustomerQuery query)
        {
            return _repository.GetById(query.Id);
        }

        public List<Customer> Handle(SearchForCustomersQuery query)
        {
            return _repository.GetCustomersByQuery(query.SearchTerm);
        }
    }
}