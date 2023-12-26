using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LightSotre.Models
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Fatura> Fatura { get; set; }
        public virtual DbSet<Kategore> Kategore { get; set; }
        public virtual DbSet<Musteri> Musteri { get; set; }
        public virtual DbSet<Odeme> Odeme { get; set; }
        public virtual DbSet<Satici> Satici { get; set; }
        public virtual DbSet<Sepet> Sepet { get; set; }
        public virtual DbSet<Siparis> Siparis { get; set; }
        public virtual DbSet<SiparisAdres> SiparisAdres { get; set; }
        public virtual DbSet<Urun> Urun { get; set; }
        public virtual DbSet<Login> Login { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fatura>()
                .HasMany(e => e.Odeme)
                .WithRequired(e => e.Fatura)
                .HasForeignKey(e => e.FauraNO)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Kategore>()
                .HasMany(e => e.Urun)
                .WithRequired(e => e.Kategore)
                .HasForeignKey(e => e.Kategore_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.MusteriIsim)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.MusteriTel)
                .IsFixedLength();

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Siparis)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Satici)
                .WithMany(e => e.Musteri)
                .Map(m => m.ToTable("MusteriSatici").MapLeftKey("MusteriId").MapRightKey("SaticiNo"));

            modelBuilder.Entity<Odeme>()
                .Property(e => e.OdemeSecenek)
                .IsFixedLength();

            modelBuilder.Entity<Satici>()
                .Property(e => e.Saticitel)
                .IsFixedLength();

            modelBuilder.Entity<Satici>()
                .HasMany(e => e.Siparis)
                .WithRequired(e => e.Satici)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Satici>()
                .HasMany(e => e.Urun)
                .WithMany(e => e.Satici)
                .Map(m => m.ToTable("SaticiUrun").MapLeftKey("SaticiNo").MapRightKey("UrunId"));

            modelBuilder.Entity<Sepet>()
                .HasMany(e => e.Odeme)
                .WithRequired(e => e.Sepet)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Siparis>()
                .Property(e => e.SiparisDurum)
                .IsFixedLength();

            modelBuilder.Entity<Siparis>()
                .HasMany(e => e.Fatura)
                .WithRequired(e => e.Siparis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Siparis>()
                .HasMany(e => e.SiparisAdres)
                .WithRequired(e => e.Siparis)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Siparis>()
                .HasMany(e => e.Urun)
                .WithMany(e => e.Siparis)
                .Map(m => m.ToTable("SiparisUrun").MapLeftKey("SiparisNo").MapRightKey("UrunId"));

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Sepet)
                .WithRequired(e => e.Urun)
                .HasForeignKey(e => e.Urun_ID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Musteri)
                .WithRequired(e => e.Login)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.Satici)
                .WithRequired(e => e.Login)
                .WillCascadeOnDelete(false);
        }
    }
}
