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

        public IActionResult Make(Guid id)
        {
            var query = new GetMakeQuery(id);
            var make = _queryProcessor.Process(query);
            return View(make);
        }

        public IActionResult Model(Guid id)
        {
            var query = new GetModelQuery(id);
            var model = _queryProcessor.Process(query);
            return View(model);
        }
    }
}