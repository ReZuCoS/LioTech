namespace LioTech.Connections
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LiIonBatteries
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string BodyMaterial { get; set; }

        [Required]
        [StringLength(50)]
        public string Capacity { get; set; }

        [StringLength(50)]
        public string Voltage { get; set; }

        public decimal? Mass { get; set; }

        [StringLength(250)]
        public string Description { get; set; }
    }
}
