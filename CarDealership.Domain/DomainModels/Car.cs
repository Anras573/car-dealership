using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Domain.DomainModels
{
    [Table("Car")]
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [ForeignKey("Model")]
        public Guid ModelId { get; set; }

        public string Extras { get; set; }
        public decimal RecommendPrice { get; set; }

        public virtual CarPurchase CarPurchase { get; set; }
        public virtual Model MakeAndModel { get; set; }
    }
}
