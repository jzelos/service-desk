using Microsoft.EntityFrameworkCore;
using System;

namespace Domain
{
    public class ServiceDeskContext : DbContext
    {
        public ServiceDeskContext(DbContextOptions<ServiceDeskContext> options)
            : base(options)
        { }
        
        public DbSet<Ticket> Tickets { get; set; }

        // Lists
        public DbSet<Category> Categories { get; set; }
        public DbSet<Source> Sources { get; set; }
    }

}