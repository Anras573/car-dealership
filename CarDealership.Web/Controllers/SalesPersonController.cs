using System;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Domain.SalesPersons.Queries;
using CarDealership.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers
{
    public class SalesPersonController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public SalesPersonController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var query = new GetAllSalesPersonsQuery();
            var salesPersons = _queryProcessor.Process(query);
            var vm = new SalesPersonViewModel
            {
                SalesPersons = salesPersons,
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

            var query = new SearchForSalesPersonsQuery(searchTerm);
            var salesPersons = _queryProcessor.Process(query);
            var vm = new SalesPersonViewModel
            {
                SalesPersons = salesPersons,
                SearchTerm = searchTerm
            };
            return View(vm);
        }

        [HttpGet("[controller]/{id}")]
        public IActionResult Get(Guid id)
        {
            var query = new GetSalesPersonQuery(id);
            var salesPerson = _queryProcessor.Process(query);
            return View(salesPerson);
        }
    }
}