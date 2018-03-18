using System.Collections.Generic;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Web.Models
{
    public class SalesPersonViewModel
    {
        public string SearchTerm { get; set; }
        public List<SalesPerson> SalesPersons { get; set; }
    }
}