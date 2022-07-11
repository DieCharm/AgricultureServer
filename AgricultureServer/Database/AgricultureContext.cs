using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AgricultureServer.Database
{
    public partial class AgricultureContext : DbContext
    {
        public AgricultureContext()
        {
        }

        public AgricultureContext(DbContextOptions<AgricultureContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttractingWorker> AttractingWorkers { get; set; }
        public virtual DbSet<Crop> Crops { get; set; }
        public virtual DbSet<CropIncomeAndExpense> CropIncomeAndExpenses { get; set; }
        public virtual DbSet<Field> Fields { get; set; }
        public virtual DbSet<PlannedRequirement> PlannedRequirements { get; set; }
        public virtual DbSet<PlannedWaybill> PlannedWaybills { get; set; }
        public virtual DbSet<SalesInvoice> SalesInvoices { get; set; }
        public virtual DbSet<TechnologicalOperation> TechnologicalOperations { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkerQualification> WorkerQualifications { get; set; }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=JACKFLASHPC;Database=Agriculture;Trusted_Connection=True;");
            }
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<AttractingWorker>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany(p => p.AttractingWorkers)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Attractin__Order__3F466844");

                entity.HasOne(d => d.Qualification)
                    .WithMany(p => p.AttractingWorkers)
                    .HasForeignKey(d => d.QualificationId)
                    .HasConstraintName("FK__Attractin__Quali__403A8C7D");
            });

            modelBuilder.Entity<Crop>(entity =>
            {
                entity.ToTable("Crop");

                entity.Property(e => e.CropName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CropIncomeAndExpense>(entity =>
            {
                entity.Property(e => e.Expenses).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Income).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.CropIncomeAndExpenses)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK__CropIncom__CropI__5CD6CB2B");
            });

            modelBuilder.Entity<Field>(entity =>
            {
                entity.ToTable("Field");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.Fields)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK__Field__CropId__267ABA7A");
            });

            modelBuilder.Entity<PlannedRequirement>(entity =>
            {
                entity.ToTable("PlannedRequirement");

                entity.Property(e => e.MaterialName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MaterialPricePerUnit).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.PlannedRequirements)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK__PlannedRe__Opera__5FB337D6");
            });

            modelBuilder.Entity<PlannedWaybill>(entity =>
            {
                entity.ToTable("PlannedWaybill");

                entity.Property(e => e.CarName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.WorkTime).HasColumnType("datetime");

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.PlannedWaybills)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK__PlannedWa__Opera__31EC6D26");
            });

            modelBuilder.Entity<SalesInvoice>(entity =>
            {
                entity.ToTable("SalesInvoice");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.SalesInvoices)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK__SalesInvo__CropI__2A4B4B5E");
            });

            modelBuilder.Entity<TechnologicalOperation>(entity =>
            {
                entity.ToTable("TechnologicalOperation");

                entity.Property(e => e.OperationName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Crop)
                    .WithMany(p => p.TechnologicalOperations)
                    .HasForeignKey(d => d.CropId)
                    .HasConstraintName("FK__Technolog__CropI__2F10007B");
            });

            modelBuilder.Entity<WorkOrder>(entity =>
            {
                entity.ToTable("WorkOrder");

                entity.Property(e => e.WorkType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Operation)
                    .WithMany(p => p.WorkOrders)
                    .HasForeignKey(d => d.OperationId)
                    .HasConstraintName("FK__WorkOrder__Opera__398D8EEE");
            });

            modelBuilder.Entity<WorkerQualification>(entity =>
            {
                entity.ToTable("WorkerQualification");

                entity.Property(e => e.HourlyPayment).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.QualificationName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
