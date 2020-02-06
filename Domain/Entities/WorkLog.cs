using Orbis.Housing.ServiceDesk.Domain.Entities.BaseClasses;
using Orbis.Housing.ServiceDesk.Domain.Utilities;
using System;

namespace Orbis.Housing.ServiceDesk.Domain.Entities
{
    public class WorkLog : Entity
    {
        public WorkLog(string creator, string comment, TimeSpan timeSpent)
        {
            Guard.NotNullOrEmpty(creator, nameof(creator));
            Guard.NotNullOrEmpty(comment, nameof(comment));
            Guard.NotNull(timeSpent, nameof(timeSpent));

            CreatedDate = DateTime.UtcNow;
            Creator = creator;
            Comment = comment;
            TimeSpent = timeSpent;
        }

        private WorkLog()
        {
        } // EF

        public string Comment { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Creator { get; private set; }
        public TimeSpan TimeSpent { get; private set; }
    }
}