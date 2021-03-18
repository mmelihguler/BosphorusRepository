using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class Project : Base
    {
        [Key]
        public override Guid Id { get; set; }
        public override DateTime CreatedAt { get; set; }
        public override DateTime UpdatedAt { get; set; }
        public override string Username { get; set; }
        public override string Password { get; set; }        
        public string ProjectName { get; set; }
        public string ProjectField { get; set; }
        public string ProjectThematicField { get; set; }
        public int    PersonNumber { get; set; }
        public string ProjectCreationDate { get; set; }
        public string ProjectPlace { get; set; }
        public override string ContactAddress {get;set;}
        public override string ContactNumber { get; set; }
        public override string ContactMail { get; set; }
    }
}