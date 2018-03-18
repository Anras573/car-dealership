using System.Collections.Generic;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Web.Models
{
    public class CustomerViewModel
    {
        public string SearchTerm { get; set; }
        public List<Customer> Customers { get; set; }
    }
}