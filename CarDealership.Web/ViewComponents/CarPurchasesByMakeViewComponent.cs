using System;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Domain.Cars.Queries;
using CarDealership.Domain.Framework.Queries;
using CarDealership.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.Web.ViewComponents
{
    public class CarPurchasesByMakeViewComponent : ViewComponent
    {
        private readonly IQueryProcessor _queryProcessor;

        public CarPurchasesByMakeViewComponent(IQueryProcessor queryProcessor)
        {
            _queryProcessor = queryProcessor;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid makeId)
        {
            var query = new GetCarPurchasesByMakeQuery(makeId);
            var purchases = _queryProcessor.Process(query);

            var vm = purchases.Select(o => new CarPartialViewModel
                {
                    Car = o.Car,
                    SalesPerson = o.SalesPerson,
                    Customer = o.Customer,
                    OrderDate = o.OrderDate,
                    SoldFor = o.PricePaid
                }).ToList();

            return View(vm);
        }
    }
}