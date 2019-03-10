using System;

namespace Domain
{
    public sealed class WorkLog : Entity
    {        
        public DateTime CreatedDate {get; set;}
        public string Creator {get; set;}
                  
        public string Comment {get; set;}
        public TimeSpan TimeSpent {get; set;}

        public WorkLog(string creator, string comment, TimeSpan timeSpent)
        {
            this.CreatedDate = DateTime.Now;
            this.Creator = creator;
            this.Comment = comment;
            this.TimeSpent = timeSpent;
        }

         protected WorkLog() { }
    }
}
