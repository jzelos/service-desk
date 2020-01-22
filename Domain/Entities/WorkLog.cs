using Domain.Entities.BaseClasses;
using System;

namespace Domain.Entities
{
    public class WorkLog : Entity
    {
        public WorkLog(string creator, string comment, TimeSpan timeSpent)
        {
            CreatedDate = DateTime.Now;
            Creator = creator;
            Comment = comment;
            TimeSpent = timeSpent;
        }

        public string Comment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public TimeSpan TimeSpent { get; set; }
    }
}