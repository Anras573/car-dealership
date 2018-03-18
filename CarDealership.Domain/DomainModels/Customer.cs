using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Domain.DomainModels
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public int Age { get; set; }

        [Required]
        public string Address { get; set; }

        public DateTime Created { get; set; }

        public virtual ICollection<CarPurchase> CarPurchases { get; set; }
    }
}
