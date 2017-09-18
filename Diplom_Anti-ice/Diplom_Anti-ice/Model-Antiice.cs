namespace Diplom_Anti_ice
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_Antiice : DbContext
    {
        public Model_Antiice()
            : base("name=ModelAntiice")
        {
        }

        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Help> Help { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Device>()
                .HasMany(e => e.Help)
                .WithRequired(e => e.Device)
                .HasForeignKey(e => e.ID_Device)
                .WillCascadeOnDelete(false);
        }
    }
}
