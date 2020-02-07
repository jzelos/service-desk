using Microsoft.AspNetCore.Mvc;
using Orbis.Housing.ServiceDesk.Domain.Entities;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly SourceRepository _sourceRepository;
        private readonly TicketRepository _ticketRepository;

        public TicketController(
            TicketRepository ticketRepository,
            SourceRepository sourceRepository,
            CategoryRepository categoryRepository)
        {
            _ticketRepository = ticketRepository;
            _sourceRepository = sourceRepository;
            _categoryRepository = categoryRepository;
        }

        [HttpPost]
        public async Task CreateTicket([FromBody] CreateTicketModel model)
        {
            var ticket = new Ticket(
                model.Creator,
                model.Source,
                model.Summary,
                model.Description,
                model.Categorisation);
            await _ticketRepository.Add(ticket);
            await _ticketRepository.Save();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(long id)
        {
            return Ok(await _ticketRepository.GetById(id));
        }

        [HttpGet("categories")]
        public async Task<ActionResult<string>> GetCategories()
        {
            return Ok(await _categoryRepository.Get());
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<string>>> GetMyTickets()
        {
            return Ok(await _ticketRepository.GetAllByAssignee("jay"));
        }

        [HttpGet("sources")]
        public async Task<ActionResult<string>> GetSources()
        {
            return Ok(await _sourceRepository.GetSourceNames());
        }

        [HttpGet("unassigned")]
        public async Task<ActionResult<IEnumerable<string>>> GetUnassigned()
        {
            return Ok(await _ticketRepository.GetAllUnassigned());
        }

        [HttpPut("{id}")]
        public async Task UpdateTicket(int id, [FromBody] UpdateTicketModel model)
        {
            var ticket = await _ticketRepository.GetById(id);
            ticket.UpdateTicket(
                model.Source,
                model.Summary,
                model.Description,
                model.Categorisation);
            await _ticketRepository.Save();
        }
    }
}