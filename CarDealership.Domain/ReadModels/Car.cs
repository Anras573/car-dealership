using System;

namespace CarDealership.Domain.ReadModels
{
    public class Car
    {
        public Guid Id { get; set; }
        public string[] Extras { get; set; }
        public decimal RecommendPrice { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }

        public CarPurchase CarPurchase { get; set; }
    }
}