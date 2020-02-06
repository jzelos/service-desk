using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Persistance;

namespace Orbis.Housing.ServiceDesk.Persistance
{
    public class ServiceDeskContextFactory : IDesignTimeDbContextFactory<ServiceDeskContext>
    {
        public ServiceDeskContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ServiceDeskContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=ServiceDesk;Integrated Security=True;App=ServiceDesk;MultipleActiveResultSets=True;");

            return new ServiceDeskContext(optionsBuilder.Options);
        }
    }
}