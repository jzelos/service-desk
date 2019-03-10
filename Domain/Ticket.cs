using System;
using System.IO;

namespace Domain
{
    public sealed class Ticket : AggregateRoot
    {
        public DateTime CreatedDate { get; private set; }
        public string Creator { get; private set; }
        public DateTime? AssignedDate { get; private set; }
        public string Assignee { get; private set; }

        public string Source { get; private set; }
        public Status Status { get; private set; }

        public string Summary { get; private set; }
        public string Description { get; private set; }

        public string Category { get; private set; }
        public string Subcategory { get; private set; }
        public string Item { get; private set; }

        public virtual ICollection<WorkLog> WorkLogs { get; set; }

        public virtual ICollection<Document> Documents { get; set; }

        public boolean IsReadOnly()
        {
            return this.Status == Status.Closed || this.Status == Status.Completed;
        }

        public Ticket(
            string user,
            string source,
            string summary,
            string description,
            string category,
            string subcategory,
            string item)
        {
            NullCheck(user);
            NullCheck(source);
            NullCheck(summary);
            NullCheck(description);
            NullCheck(category);
            NullCheck(subcategory);
            NullCheck(item);

            this.CreatedDate = DateTime.Now;
            this.Creator = user;
            this.Source = source;
            this.Summary = summary;
            this.Description = description;
            this.Category = category;
            this.Subcategory = subcategory;
            this.Item = item;
            this.Status = Status.Unassigned;
            ticket.Documents = new List<Document>();
            ticket.WorkLogs = new List<WorkLog>();
        }

        protected Ticket() { }

        // Commands
        public void AddDocument(string user, string filename, byte[] data)
        {
            ReadOnlyCheck();
            NullCheck(user);
            NullCheck(filename);
            if (date == null || data.Length == 0)
                throw new ArgumentNullException("File data has a length of zero");

            var fileIdentifier = Guid.NewGuid();
            var path = Path.Combine("c:\temp", fileIdentifier);
            using (FileStream stream = File.Open(path, FileMode.Create, File.Write))
            {
                stream.Write(data);
            }

            var document = new Document(user, filename, fileIdentifier);
            this.Documents.Add(document);
        }

        public void DeleteDocument(long id)
        {
            ReadOnlyCheck();

            var document = this.Documents.FirstOrDefault(f => f.id == id);
            if (document != null)
            {
                var path = Path.Combine("c:\temp", document.FileIdentifier);
                File.Delete(path);
                this.Documents.Remove(document);
            }
        }

        // AddWorklog        
        public void AddWorklog(string user, string comment, TimeSpan timeSpent)
        {
            ReadOnlyCheck();

            if (string.IsNullOrEmpty(user)
                || string.IsNullOrEmpty(comment))
                throw new Exception("Missing parameters");

            var worklog = new WorkLog(user, comment, timeSpent);
            this.Worklogs.Add(worklog);
        }

        // ReassignTicket
        public void ReassignTicket(string user, string assignee)
        {
            if (this.IsReadOnly)
                return;

            this.AddWorklog(user, $"Ticket assigned to {assignee}", new TimeSpan());
            this.Assignee = assignee;
            this.AssignedDate = DateTime.Now;
        }

        // CloseTicket
        public void CloseTicket(string user)
        {
            if (this.IsReadOnly)
                return;

            this.AddWorklog(user, $"Ticket closed", new TimeSpan());
            this.Status = Status.Closed;
        }

        // CompleteTicket
        public void CompleteTicket(string user)
        {
            if (this.Status == Status.WorkInProgress || this.Status == Status.Paused)
            {
                this.AddWorklog(user, $"Ticket completed", new TimeSpan());
                this.Status = Status.Completed;
            }
        }

        // PauseTicket
        public void PauseTicket(string user)
        {
            if (this.Status == Status.WorkInProgress)
            {
                this.AddWorklog(user, $"Ticket paused", new TimeSpan());
                this.Status = Status.Paused;
            }
        }

        // StartWork
        public void StartWork(string user)
        {
            if (this.Status == Status.Assigned)
            {
                this.AddWorklog(user, $"Ticket work started", new TimeSpan());
                this.Status = Status.WorkInProgress;
                return;
            }
            if (this.Status == Status.Paused)
            {
                this.AddWorklog(user, $"Ticket work resumed", new TimeSpan());
                this.Status = Status.WorkInProgress;
                return;
            }
        }

        // UpdateTicket (CTI, Summary, Description)        
        public void UpdateTicket(string source, string summary, string description, string category, string subcategory, string item)
        {
            ReadOnlyCheck();
            NullCheck(source);
            NullCheck(summary);
            NullCheck(description);
            NullCheck(category);
            NullCheck(subcategory);
            NullCheck(item);

            this.Source = source;
            this.Summary = summary;
            this.Description = description;
            this.Category = category;
            this.Subcategory = subcategory;
            this.Item = item;
        }

        private void ReadOnlyCheck()
        {
            if (this.IsReadOnly)
                throw new InvalidOperationException("Cannot update a read only ticket");
        }
    }
}
