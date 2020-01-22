using Domain.Entities;

namespace Api.Controllers
{
    public class UpdateTicketModel
    {
        public Categorisation Categorisation;
        public string Description;
        public string Source;
        public string Summary;
    }
}