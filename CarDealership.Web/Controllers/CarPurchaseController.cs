using System;
using System.Linq;
using CarDealership.Domain.CarPurchases.Queries;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers
{
    public class CarPurchaseController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public CarPurchaseController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var query = new GetAllCarPurchasesQuery();
            var sales = _queryProcessor.Process(query);
            var vm = new SalesViewModel()
            {
                Sales = sales,
                StartDate = sales.First().OrderDate,
                EndDate = DateTime.Today
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Index(DateTime startDate, DateTime endDate)
        {
            var query = new SearchForCarPurchasesQuery(startDate, endDate);
            var sales = _queryProcessor.Process(query);
            var vm = new SalesViewModel
            {
                Sales = sales,
                StartDate = startDate,
                EndDate = endDate
            };
            return View(vm);
        }

        [HttpGet("[controller]/{id}")]
        public IActionResult Get(Guid id)
        {
            var query = new GetCarPurchaseQuery(id);
            var salesPerson = _queryProcessor.Process(query);
            return View(salesPerson);
        }
    }
}