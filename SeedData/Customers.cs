using System;
using System.Collections.Generic;
using CarDealership.Domain.DomainModels;

namespace SeedData
{
    public static class Customers
    {
        private static readonly List<string> MaleNames = new List<string> { "Ashton", "Ellis", "Jackson", "Jack", "Dylan", "Trevon", "Edwin", "Kayson", "Madden", "Channing" };
        private static readonly List<string> FemaleNames = new List<string> { "Eleanor", "Courtney", "Shannon", "Sophia", "Erin", "Anne", "Alivia", "Bryn", "Anika", "Lara" };
        private static readonly List<string> Surnames = new List<string> { "Elliott", "Phillips", "Reid", "Clark", "Dixon", "Holland", "Russo", "Nieves", "Calhoun", "Morris", "Dawson", "Frazier", "Kerr", "Foster", "Fisher", "Turner", "Thomas", "Hopkins", "Bailey", "Price" };
        private static readonly List<string> Streets = new List<string> { "Heart Lane", "Silver Way", "Mason Street", "Knight Avenue", "Apollo Street", "Dove Route", "Orchard Street", "Long Boulevard", "Earl Avenue", "Colonel Street", "University Lane", "Ocean Passage", "Ocean Street", "Sunshine Boulevard", "Revolution Avenue", "Grand Way", "Brewer Lane", "Elmwood Lane", "Windmill Street", "Parkview Boulevard" };

        public static List<Customer> Get()
        {
            var customers = new List<Customer>();

            foreach (var name in MaleNames)
            {
                customers.Add(new Customer
                {
                    Age = Util.Random.Next(18, 75),
                    Address = Streets[Util.Random.Next(Streets.Count)] + " " + Util.Random.Next(1, 150),
                    Created = Util.RandomDate(),
                    Id = Guid.NewGuid(),
                    Name = name,
                    Surname = Surnames[Util.Random.Next(Surnames.Count)]
                });
            }

            foreach (var name in FemaleNames)
            {
                customers.Add(new Customer
                {
                    Age = Util.Random.Next(18, 75),
                    Address = Streets[Util.Random.Next(Streets.Count)] + " " + Util.Random.Next(1, 150),
                    Created = Util.RandomDate(),
                    Id = Guid.NewGuid(),
                    Name = name,
                    Surname = Surnames[Util.Random.Next(Surnames.Count)]
                });
            }

            return customers;
        }
    }
}