using System;
using Xunit;

namespace Domain.Test
{
    public class CreateTicket
    {
        [Fact]
        public void CreatesTicket()
        {
            var sut = new ServiceDesk();

            var ticket = sut.CreateTicket("creator", "source", "summary", "description", "category", "subcategory", "item");

            Assert.Equals("creator", ticket.Creator);
            Assert.Equals("source", ticket.Source);
            Assert.Equals("summary", ticket.Summary);
            Assert.Equals("description", ticket.Description);
            Assert.Equals("category", ticket.Category);
            Assert.Equals("subcategory", ticket.Subcategory);
            Assert.Equals("item", ticket.Item);
            Assert.Equals(1, sut.Tickets.Count());

        }
    }
}
