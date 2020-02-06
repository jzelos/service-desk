using Orbis.Housing.ServiceDesk.Domain.Entities;

namespace Api.Controllers
{
    public class CreateTicketModel
    {
        public Categorisation Categorisation;
        public string Creator;
        public string Description;
        public string Source;
        public string Summary;
    }
}