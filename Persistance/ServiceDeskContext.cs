using Microsoft.EntityFrameworkCore;
using Orbis.Housing.ServiceDesk.Domain.Entities;
using System;

namespace Persistance
{
    public class ServiceDeskContext : DbContext
    {
        public ServiceDeskContext(DbContextOptions<ServiceDeskContext> options)
            : base(options)
        { }

        // Lists
        public DbSet<Category> Categories { get; set; }

        public DbSet<Source> Sources { get; set; }

        // Tickets
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Source>(entity =>
            {
                entity.HasKey(k => k.Name);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            //modelBuilder.Entity<Subcategory>(entity =>
            //{
            //    entity.ToTable("Subcategories");
            //    entity.HasKey(k => k.Name);
            //    entity.Property(p => p.Name)
            //        .IsRequired()
            //        .HasMaxLength(50);
            //});

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(k => k.Name);

                entity.Property(p => p.Name)
                    .IsRequired()
                    .HasMaxLength(50);
                //entity.Metadata.FindNavigation("Subcategories")
                //    .SetPropertyAccessMode(PropertyAccessMode.Field);
            });

            modelBuilder.Entity<WorkLog>(entity =>
            {
                entity.ToTable("WorkLogs");

                entity.Property(p => p.Creator)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(p => p.Comment)
                    .IsRequired();
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(p => p.Assignee)
                    .HasMaxLength(50);
                entity.Property(p => p.Creator)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(p => p.Source)
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(e => e.Status)
                   .HasConversion(
                       v => v.ToString(),
                       v => (Status)Enum.Parse(typeof(Status), v));
                entity.OwnsOne(o => o.Categorisation, owned =>
                {
                    owned.Property(p => p.Category)
                        .IsRequired() // seems to get ignored in owned property, https://github.com/dotnet/efcore/issues/12100
                        .HasMaxLength(50);
                    owned.Property(p => p.Subcategory)
                        .IsRequired()
                        .HasMaxLength(50);
                });
                entity.Property(p => p.Summary)
                    .IsRequired()
                    .HasMaxLength(200);
                entity.Property(p => p.Description)
                    .IsRequired();

                entity.HasMany(n => n.WorkLogs)
                    .WithOne()
                    .HasForeignKey("TicketId")
                    .IsRequired(); // force shadow field to be required (otherwise will be nullable)

                entity.Metadata.FindNavigation("WorkLogs")
                    .SetPropertyAccessMode(PropertyAccessMode.Field);
            });
        }
    }
}