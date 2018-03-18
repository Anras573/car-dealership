using System;
using System.Collections.Generic;
using CarDealership.Domain.DomainModels;

namespace SeedData
{
    public class Cars
    {
        private static readonly List<string> Extras = new List<string> { "Metallic Paint", "Premium Metallic Paint", "Pearlescent Paint", "18’’ Alloy wheels", "Smart Vision Pack", "Tech Pack", "Comfort Pack", "Glass Roof Pack", "Heat Pack", "LED Pack", "Executive Pack" };

        public static List<Make> GetMakes()
        {
            return new List<Make>
            {
                new Make
                {
                    Id = Guid.NewGuid(),
                    Name = "Audi",
                    Models = new List<Model>
                    {
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "A3"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "A4"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Q2"
                        }
                    }
                },
                new Make
                {
                    Id = Guid.NewGuid(),
                    Name = "Toyota",
                    Models = new List<Model>
                    {
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Aygo"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "C-HR"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Avensis"
                        }
                    }
                },
                new Make
                {
                    Id = Guid.NewGuid(),
                    Name = "Nissan",
                    Models = new List<Model>
                    {
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Micra"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Juke"
                        },
                    }
                },
                new Make
                {
                    Id = Guid.NewGuid(),
                    Name = "Tesla",
                    Models = new List<Model>
                    {
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Model S"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Model X"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "Model 3"
                        }
                    }
                },
                new Make
                {
                    Id = Guid.NewGuid(),
                    Name = "Volvo",
                    Models = new List<Model>
                    {
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "XC90"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "V90"
                        },
                        new Model
                        {
                            Id = Guid.NewGuid(),
                            Name = "S90"
                        }
                    }
                }
            };
        }

        public static List<Car> GetCars(List<Model> models)
        {
            var cars = new List<Car>();
            foreach (var model in models)
            {
                for (var i = 0; i < 10; i++)
                {
                     var car = new Car
                     {
                         Id = Guid.NewGuid(),
                         MakeAndModel = model,
                         RecommendPrice = Util.Random.Next(100_000, 1_000_000),
                         Extras = GetExtras()
                     };

                    cars.Add(car);
                }
            }
            return cars;
        }

        private static string GetExtras()
        {
            var extra = string.Empty;
            var numberOfExtras = Util.Random.Next(5);
            for (var i = 0; i < numberOfExtras; i++)
            {
                extra += Extras[Util.Random.Next(Extras.Count)];
                if (i < numberOfExtras - 1)
                {
                    extra += ";";
                }
            }
            return extra;
        }
    }
}