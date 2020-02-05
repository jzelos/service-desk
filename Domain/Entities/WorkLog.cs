using Domain.Entities.BaseClasses;
using System;

namespace Domain.Entities
{
    public class WorkLog : Entity
    {
        public WorkLog(string creator, string comment, TimeSpan timeSpent)
        {
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