using System;
using CarDealership.Domain.DomainModels;

namespace CarDealership.Domain.ReadModels
{
    public class CarPurchase
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal PricePaid { get; set; }

        public Customer Customer { get; set; }
        public Car Car { get; set; }
        public SalesPerson SalesPerson { get; set; }
    }
}