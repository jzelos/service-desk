using Domain.Entities.BaseClasses;
using System;

namespace Domain.Entities
{
    public class Document : Entity
    {
        public Document(string creator, string filename, Guid fileIdentifier)
        {
            CreatedDate = DateTime.Now;
            Creator = creator;
            Filename = filename;
            FileIdentifier = fileIdentifier;
        }

        public DateTime CreatedDate { get; set; }
        public string Creator { get; set; }
        public Guid FileIdentifier { get; set; }
        public string Filename { get; set; }
    }
}