namespace LioTech.Connections
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Deliveries
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(100)]
        public string Product { get; set; }

        [Column(TypeName = "date")]
        public DateTime DepartureDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReceivingDate { get; set; }

        [Required]
        [StringLength(25)]
        public string Status { get; set; }
    }
}
