namespace autoshopbiz.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class RepairShopContext : DbContext
    {
        public RepairShopContext()
            : base("name=RepairShopContext")
        {
        }

        public virtual DbSet<customer_vehicles> customer_vehicles { get; set; }
        public virtual DbSet<customer> customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<customer_vehicles>()
                .Property(e => e.create_date)
                .IsFixedLength();

            modelBuilder.Entity<customer>()
                .Property(e => e.create_date)
                .IsFixedLength();

            modelBuilder.Entity<customer>()
                .Property(e => e.customer_comment)
                .IsUnicode(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.customer_vehicles)
                .WithOptional(e => e.customer)
                .HasForeignKey(e => e.customer_id);
        }
    }
}
