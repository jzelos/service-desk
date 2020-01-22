using Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace Domain.Test
{
    public class Constructor
    {
        [Test]
        public void CreatesNewTicket()
        {
            var now = new DateTime(2020, 1, 1);
            var catagorisation = new Categorisation("category", "subcategory");
            var ticket = new Ticket("creator", now, "source", "summary", "description", catagorisation);

            ticket.Creator.Should().Be("creator");
            ticket.CreatedDate.Should().Be(now);
            ticket.Source.Should().Be("source");
            ticket.Summary.Should().Be("summary");
            ticket.Description.Should().Be("description");
            ticket.Categorisation.Should().Be(catagorisation);
            ticket.Status.Should().Be(Status.Unassigned);
        }
    }
}