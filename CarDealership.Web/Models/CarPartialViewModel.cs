using System;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Web.Models
{
    public class CarPartialViewModel
    {
        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public SalesPerson SalesPerson { get; set; }
        public decimal SoldFor { get; set; }
    }
}