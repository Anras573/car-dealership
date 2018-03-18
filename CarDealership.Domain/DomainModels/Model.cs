using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Domain.DomainModels
{
    [Table("Model")]
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        [ForeignKey("Make")]
        public Guid MakeId { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Make Make { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
    }
}
