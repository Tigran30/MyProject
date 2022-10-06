using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ServicesAPI.Models
{
    public partial class ServiceCatalogContext : DbContext
    {
        public ServiceCatalogContext()
        {
        }

        public ServiceCatalogContext(DbContextOptions<ServiceCatalogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Service> Services { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("ServiceDb");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedTime).HasColumnType("date");

                entity.Property(e => e.ServiceName).HasMaxLength(50);

                entity.Property(e => e.UpdatedTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
