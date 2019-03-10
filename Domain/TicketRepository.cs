using System;

namespace Domain
{
    public class TicketRepository
    {
        private readonly ServiceDeskContext _content;

        public SourceRepository(ServiceDeskContext context)
        {
            context = _content;
        }

        // CreateTicket
        public void CreateTicket(Ticket newTicket)
        {
            _content.Tickets.Add(newTicket);
        }

        // GetAllUnassigned
        public IReadOnlyCollection<Ticket> GetAllUnassigned()
        {
            return _context.Tickets.Where(t => t.Status == Status.Unassigned);
        }

        // GetAllByAssignee
        public IReadOnlyCollection<Ticket> GetAllByAssignee(string assignee)
        {
            return _context.Tickets.Where(t => t.Assignee == assignee);
        }

        // Save
        public void Save()
        {
            _content.SaveChanges();
        }
    }
}
