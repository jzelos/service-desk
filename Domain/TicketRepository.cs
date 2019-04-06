using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class TicketRepository
    {
        private readonly ServiceDeskContext _context;

        public TicketRepository(ServiceDeskContext context)
        {
            _context = context;
        }

        // CreateTicket
        public void CreateTicket(Ticket newTicket)
        {
            _context.Tickets.Add(newTicket);
        }

        // GetAllUnassigned
        public IReadOnlyCollection<Ticket> GetAllUnassigned()
        {
            return _context.Tickets.Where(t => t.Status == Status.Unassigned).ToList();
        }

        // GetAllByAssignee
        public IReadOnlyCollection<Ticket> GetAllByAssignee(string assignee)
        {
            return _context.Tickets.Where(t => t.Assignee == assignee).ToList();
        }

        // GetTicketById
        public Ticket GetTicketById(long id)
        {
            return _context.Tickets.First(w => w.Id == id);            
        }

        // Save
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
