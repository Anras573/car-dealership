using System;
using System.Collections.Generic;

namespace CarDealership.Domain.ReadModels
{
    public class Make
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Model> Models { get; set; }
    }
}