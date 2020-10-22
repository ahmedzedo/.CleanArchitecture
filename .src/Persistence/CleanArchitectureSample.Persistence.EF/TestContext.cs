using CleanArchitectureSample.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CleanArchitectureSample.Persistence.EF
{
    /// <summary>
    /// TestContext
    /// </summary>
    /// <remarks></remarks>
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attatchment> Attatchment { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageConfigFile> PackageConfigFile { get; set; }
        public virtual DbSet<Terminal> Terminal { get; set; }
        public virtual DbSet<TerminalPackage> TerminalPackage { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["Test"].ConnectionString);// "Server=.;Database=Test;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Attatchment>(entity =>
            {
                entity.Property(e => e.Extension).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Attatchments)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_Attatchment_Package");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(150);
            });

            modelBuilder.Entity<PackageConfigFile>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackageConfigFiles)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_PackageConfigFile_Package");
            });

            modelBuilder.Entity<Terminal>(entity =>
            {
                entity.Property(e => e.Model).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Tid)
                    .HasColumnName("TID")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TerminalPackage>(entity =>
            {
                entity.HasOne(d => d.Package)
                    .WithMany(p => p.TerminalPackages)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("FK_TerminalPackage_Package");

                entity.HasOne(d => d.Terminal)
                    .WithMany(p => p.TerminalPackages)
                    .HasForeignKey(d => d.TerminalId)
                    .HasConstraintName("FK_TerminalPackage_Terminal");
            });
        }
    }
}
