using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Model
{
    public class Investor : Base
    {
        [Key]
        public override Guid Id { get; set; }
        public override DateTime CreatedAt { get; set; }
        public override DateTime UpdatedAt { get; set; }        
        public override string Username { get; set; }
        public override string Password { get; set; }        
        public string InvestorName { get; set; }
        public string InvestorInterestedField { get; set; }
        public override string ContactAddress {get;set;}
        public override string ContactNumber { get; set; }
        public override string ContactMail { get; set; }
    }
}