using System;
using System.Collections.Generic;

namespace CarDealership.Domain.ReadModels
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public DateTime Created { get; set; }

        public List<CarPurchase> CarPurchases { get; set; }
    }
}