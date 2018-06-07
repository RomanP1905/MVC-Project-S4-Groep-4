namespace ProjectAO_Wagenpark.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WagenparkDBModel : DbContext
    {
        public WagenparkDBModel()
            : base("name=WagenparkDBModel1")
        {
        }

        public virtual DbSet<Auto> Auto { get; set; }
        public virtual DbSet<Dealer> Dealer { get; set; }
        public virtual DbSet<Onderhoud> Onderhoud { get; set; }
        public virtual DbSet<Werkplaats> Werkplaats { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>()
                .Property(e => e.kenteken)
                .IsFixedLength();

            modelBuilder.Entity<Auto>()
                .HasMany(e => e.Onderhoud)
                .WithRequired(e => e.Auto)
                .HasForeignKey(e => e.auto_kenteken)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Dealer>()
                .HasMany(e => e.Auto)
                .WithRequired(e => e.Dealer)
                .HasForeignKey(e => e.DEALER_DealerNr)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Onderhoud>()
                .Property(e => e.kosten)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Onderhoud>()
                .Property(e => e.auto_kenteken)
                .IsFixedLength();

            modelBuilder.Entity<Werkplaats>()
                .HasMany(e => e.Onderhoud)
                .WithRequired(e => e.Werkplaats)
                .HasForeignKey(e => e.werkplaats_werkplaatsnr)
                .WillCascadeOnDelete(false);
        }
    }
}
