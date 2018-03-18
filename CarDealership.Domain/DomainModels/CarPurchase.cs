using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Domain.DomainModels
{
    [Table("CarPurchase")]
    public class CarPurchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [ForeignKey("Car")]
        public Guid CarId { get; set; }

        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }

        [ForeignKey("SalesPerson")]
        public Guid SalesPersonId { get; set; }

        public DateTime OrderDate { get; set; }
        public decimal PricePaid { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
    }
}