using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LioTech.Connections
{
    public partial class Model_LioTech : DbContext
    {
        public Model_LioTech()
            : base("name=Model_LioTech")
        {
        }

        public virtual DbSet<Deliveries> Deliveries { get; set; }
        public virtual DbSet<Different> Different { get; set; }
        public virtual DbSet<LiIonBatteries> LiIonBatteries { get; set; }
        public virtual DbSet<NetworkedEnergyStorage> NetworkedEnergyStorage { get; set; }
        public virtual DbSet<TractionBatteries_EBus> TractionBatteries_EBus { get; set; }
        public virtual DbSet<TractionBatteries_SpecialEq> TractionBatteries_SpecialEq { get; set; }
        public virtual DbSet<UninterruptiblePowerSupplies> UninterruptiblePowerSupplies { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LiIonBatteries>()
                .Property(e => e.Mass)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TractionBatteries_EBus>()
                .Property(e => e.Mass)
                .HasPrecision(15, 2);

            modelBuilder.Entity<TractionBatteries_SpecialEq>()
                .Property(e => e.Mass)
                .HasPrecision(15, 2);
        }
    }
}
