using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Domain.DomainModels
{
    [Table("SalesPerson")]
    public class SalesPerson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [ForeignKey("JobTitle")]
        public Guid JobTitleId { get; set; }

        public virtual JobTitle JobTitle { get; set; }
        public virtual ICollection<CarPurchase> Sales { get; set; }
    }
}