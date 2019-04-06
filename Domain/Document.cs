using System;

namespace Domain
{
    public class Document : Entity
    {    
        public DateTime CreatedDate {get; set;}
        public string Creator {get; set;}        
        public string Filename {get; set;}
        public Guid FileIdentifier {get; set;}

        public Document(string creator, string filename, Guid fileIdentifier)
        {
            this.CreatedDate = DateTime.Now;
            this.Creator = creator;
            this.Filename = filename;
            this.FileIdentifier = fileIdentifier;
        }

        protected Document() { }
    }
}
