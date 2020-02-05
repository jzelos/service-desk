using Domain.Entities.BaseClasses;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Ticket : AggregateRoot
    {
        // private readonly List<Document> _documents = new List<Document>();
        private readonly List<WorkLog> _workLogs = new List<WorkLog>();

        public Ticket(
            string creator,
            DateTime createdDate,
            string source,
            string summary,
            string description,
            Categorisation categorisation)
        {
            NullCheck(creator);
            NullCheck(source);
            NullCheck(summary);
            NullCheck(description);
            NullCheck(categorisation);

            CreatedDate = createdDate;
            Creator = creator;
            Source = source;
            Description = description;
            Summary = summary;
            Categorisation = categorisation;
            Status = Status.Unassigned;
        }

        private Ticket()
        {
        } // EF

        public DateTime? AssignedDate { get; private set; }
        public string Assignee { get; private set; }
        public Categorisation Categorisation { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string Creator { get; private set; }
        public string Description { get; private set; }

        // public IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();
        public string Source { get; private set; }

        public Status Status { get; private set; }
        public string Summary { get; private set; }
        public IReadOnlyCollection<WorkLog> WorkLogs => _workLogs.AsReadOnly();

        // Commands
        //public void AddDocument(string user, string filename, byte[] data)
        //{
        //    ReadOnlyCheck();
        //    NullCheck(user);
        //    NullCheck(filename);
        //    if (data == null || data.Length == 0)
        //        throw new ArgumentNullException("File data has a length of zero");

        //    var fileIdentifier = Guid.NewGuid();
        //    var path = Path.Combine("c:\temp", fileIdentifier.ToString());
        //    using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.Write))
        //    {
        //        stream.Write(data);
        //    }

        //    var document = new Document(user, filename, fileIdentifier);
        //    _documents.Add(document);
        //}

        // AddWorklog
        public void AddWorklog(string user, string comment, TimeSpan timeSpent)
        {
            ReadOnlyCheck();

            if (string.IsNullOrEmpty(user)
                || string.IsNullOrEmpty(comment))
                throw new Exception("Missing parameters");

            var worklog = new WorkLog(user, comment, timeSpent);
            _workLogs.Add(worklog);
        }

        // CloseTicket
        public void CloseTicket(string user)
        {
            if (IsReadOnly())
                return;

            AddWorklog(user, $"Ticket closed", new TimeSpan());
            Status = Status.Closed;
        }

        // CompleteTicket
        public void CompleteTicket(string user)
        {
            if (Status == Status.InProgress || Status == Status.Paused)
            {
                AddWorklog(user, $"Ticket completed", new TimeSpan());
                Status = Status.Completed;
            }
        }

        //public void DeleteDocument(long id)
        //{
        //    ReadOnlyCheck();

        //    var document = Documents.FirstOrDefault(f => f.Id == id);
        //    if (document != null)
        //    {
        //        var path = Path.Combine("c:\temp", document.FileIdentifier.ToString());
        //        File.Delete(path);
        //        _documents.Remove(document);
        //    }
        //}

        public bool IsReadOnly() => Status == Status.Closed || Status == Status.Completed;

        // PauseTicket
        public void PauseTicket(string user)
        {
            if (Status == Status.InProgress)
            {
                AddWorklog(user, $"Ticket paused", new TimeSpan());
                Status = Status.Paused;
            }
        }

        // ReassignTicket
        public void ReassignTicket(string user, string assignee)
        {
            if (IsReadOnly())
                return;

            AddWorklog(user, $"Ticket assigned to {assignee}", new TimeSpan());
            Assignee = assignee;
            AssignedDate = DateTime.Now;
        }

        // StartWork
        public void StartWork(string user)
        {
            if (Status == Status.Assigned)
            {
                AddWorklog(user, $"Ticket work started", new TimeSpan());
                Status = Status.InProgress;
                return;
            }
            if (Status == Status.Paused)
            {
                AddWorklog(user, $"Ticket work resumed", new TimeSpan());
                Status = Status.InProgress;
                return;
            }
        }

        // UpdateTicket (CTI, Summary, Description)
        public void UpdateTicket(string source, string summary, string description, Categorisation categorisation)
        {
            ReadOnlyCheck();
            NullCheck(source);
            NullCheck(summary);
            NullCheck(description);
            NullCheck(categorisation);

            Source = source;
            Summary = summary;
            Description = description;
            Categorisation = categorisation;
        }

        private void ReadOnlyCheck()
        {
            if (IsReadOnly())
                throw new InvalidOperationException("Cannot update a read only ticket");
        }
    }
}