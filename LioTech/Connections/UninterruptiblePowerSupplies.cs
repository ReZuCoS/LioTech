namespace LioTech.Connections
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UninterruptiblePowerSupplies
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string MaxPower { get; set; }

        [Required]
        [StringLength(50)]
        public string Capacity { get; set; }

        [StringLength(50)]
        public string Voltage { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
