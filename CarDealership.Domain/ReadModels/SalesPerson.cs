using System;
using System.Collections.Generic;

namespace CarDealership.Domain.ReadModels
{
    public class SalesPerson
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }

        public List<CarPurchase> Sales { get; set; }
    }
}