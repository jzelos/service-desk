using Domain.Entities;
using Domain.Repositories.BaseClasses;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class TicketRepository : Repository<Ticket>
    {
        private readonly ServiceDeskContext _context;

        public TicketRepository(ServiceDeskContext context)
        {
            _context = context;
        }

        public override async Task Add(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task<List<Ticket>> GetAllByAssignee(string assignee)
        {
            return await _context.Tickets
                .Where(t => t.Assignee == assignee)
                .ToListAsync();
        }

        public async Task<List<Ticket>> GetAllUnassigned()
        {
            return await _context.Tickets
                .Where(t => t.Status == Status.Unassigned)
                .ToListAsync();
        }

        public override async Task<Ticket> GetById(long id)
        {
            return await _context.Tickets.FirstAsync(w => w.Id == id);
        }

        public override async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}