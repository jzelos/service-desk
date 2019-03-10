using System;

namespace Domain
{
    public class ServiceDesk
    {
        public IReadOnlyCollection<Ticket> Tickets {get; private set;}

        // Commands

        // CreateTicket
         public Ticket CreateTicket(             
            string creator, 
            string source, 
            string summary, 
            string description,
            string category, 
            string subcategory, 
            string item) 
        {
            var ticket = new Ticket(creator, source, summary, description, category, subcategory, item);
            this.Tickets.Add(ticket);
        } 

        public List<Ticket> GetTicketsByUser(string user)
        {
            return this.Tickets.Where(w=>w.Assignee == user).ToList();
        }

        public Ticket GetTicketById(long id)
        {
            var ticket = this.Tickets.FirstOrDefault(w=>w.id == id);
            if (ticket1==null)
                return ticket;
            return null;
        }
    }
}
