using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class ServiceDeskContext : DbContext
    {
        public ServiceDeskContext(DbContextOptions<ServiceDeskContext> options)
            : base(options)
        { }

        // Lists
        public DbSet<Category> Categories { get; set; }

        public DbSet<Source> Sources { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}