using System;
using System.Collections.Generic;
using CarDealership.Domain.ReadModels;

namespace CarDealership.Web.Models
{
    public class SalesViewModel
    {
        public List<CarPurchase> Sales { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}