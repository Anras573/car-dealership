using System;
using System.Collections.Generic;
using CarDealership.Domain.DomainModels;

namespace SeedData
{
    public static class SalesPersons
    {
        private static readonly List<string> Names = new List<string> { "Harrison Wood", "Ethan Sharp", "Reuben Collins", "Michael Rose", "Ben James", "Cole Armstrong", "Esteban Vargas", "Zander Larsen", "Davin Jones", "Marcos Austin", "Lara Hunt", "Madison Elliott", "Kayleigh Wells", "Katie Brooks", "Scarlett Young", "Fernanda Woodard", "Makenzie Kirkland", "Evalyn Rush", "Temperance Stafford", "Angel Nelson" };
        private static readonly List<string> Streets = new List<string> {"Penrose Way", "Market Passage", "Innovation Lane", "Marble Way", "Clearance Boulevard", "Blossom Boulevard", "Emerald Lane", "Redwood Street", "Pioneer Route", "Feathers Avenue" };

        public static List<JobTitle> JobTitlesWithSalesPersons()
        {
            return new List<JobTitle>
            {
                new JobTitle
                {
                    Id = Guid.NewGuid(),
                    Title = "Sales Assistant",
                    SalesPersons = GetSalesPersons()
                },
                new JobTitle
                {
                    Id = Guid.NewGuid(),
                    Title = "Sales Associate",
                    SalesPersons = GetSalesPersons()
                },
                new JobTitle
                {
                    Id = Guid.NewGuid(),
                    Title = "Sales Manager",
                    SalesPersons = GetSalesPersons()
                }
            };
        }

        private static List<SalesPerson> GetSalesPersons()
        {
            var salesPersons = new List<SalesPerson>();

            for (var i = 0; i < 3; i++)
            {
                salesPersons.Add(new SalesPerson
                {
                    Id = Guid.NewGuid(),
                    Name = Names[Util.Random.Next(Names.Count)],
                    Address = Streets[Util.Random.Next(Streets.Count)] + " " + Util.Random.Next(1, 150),
                    Salary = Util.Random.Next(21_000, 83_000)
                });
            }

            return salesPersons;
        }
    }
}