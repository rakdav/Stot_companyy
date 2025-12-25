using Microsoft.EntityFrameworkCore;

namespace Stot_company.DataAss.Entity
{
    public partial class GgContext : DbContext
    {
        public GgContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Const_Comp> Consts { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.IdClient);

                entity.Property(e => e.Email).HasMaxLength(255);
                entity.Property(e => e.LastNameClient)
                    .HasMaxLength(255)
                    .HasColumnName("Last_name_Client");
                entity.Property(e => e.NameClient)
                    .HasMaxLength(255)
                    .HasColumnName("Name_Client");
                entity.Property(e => e.Payment).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.Sex).HasMaxLength(255);
            });

            modelBuilder.Entity<Const_Comp>(entity =>
            {
                entity.HasKey(e => e.IdComp);

                entity.Property(e => e.Location).HasMaxLength(255);
                entity.Property(e => e.NameComp)
                    .HasMaxLength(255)
                    .HasColumnName("Name_Comp");
                entity.Property(e => e.WorkPrice)
                    .HasMaxLength(255)
                    .HasColumnName("Work_Price");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.DateOrder).HasColumnName("Date_Order");
                entity.Property(e => e.NameOrder)
                    .HasMaxLength(255)
                    .HasColumnName("Name_Order");

                entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orders_Clients_FK");

                entity.HasOne(d => d.IdCompNavigation).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdComp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Orders_Consts_FK");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.HasKey(e => e.IdWorker);

                entity.Property(e => e.LastNameWorker)
                    .HasMaxLength(255)
                    .HasColumnName("Last_Name_Worker");
                entity.Property(e => e.NameWorker)
                    .HasMaxLength(255)
                    .HasColumnName("Name_Worker");
                entity.Property(e => e.Post).HasMaxLength(255);

                entity.HasOne(d => d.IdCompNavigation).WithMany(p => p.Workers)
                    .HasForeignKey(d => d.IdComp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Workers_Consts_FK");
            });

        }
    }
}

