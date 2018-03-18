using System;
using CarDealership.Domain.Cars.Queries;
using CarDealership.Domain.Framework.Queries;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly IQueryProcessor _queryProcessor;

        public CarController(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var query = new GetAllMakesQuery();
            var makes = _queryProcessor.Process(query);
            return View(makes);
        }

        [HttpGet("[controller]/{id}")]
        public IActionResult Get(Guid id)
        {
            var query = new GetMakeQuery(id);
            var customer = _queryProcessor.Process(query);
            return View(customer);
        }
    }
}