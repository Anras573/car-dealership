using System;
using CarDealership.Domain.Customers.Queries;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public CustomerController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var query = new GetAllCustomersQuery();
            var customers = _queryProcessor.Process(query);
            var vm = new CustomerViewModel
            {
                Customers = customers,
                SearchTerm = string.Empty
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return Index();
            }

            var query = new SearchForCustomersQuery(searchTerm);
            var customers = _queryProcessor.Process(query);
            var vm = new CustomerViewModel
            {
                Customers = customers,
                SearchTerm = searchTerm
            };
            return View(vm);
        }

        [HttpGet("[controller]/{id}")]
        public IActionResult Get(Guid id)
        {
            var query = new GetCustomerQuery(id);
            var customer = _queryProcessor.Process(query);
            return View(customer);
        }
    }
}