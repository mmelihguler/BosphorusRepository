using System;

namespace Entities.Model
{
    public abstract class Base
    {
        public abstract Guid Id { get; set; }   //Identificate all records

        protected Base()
        {
            Id = Id;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now; //Save times where the creation or update of records happened
        }
        public abstract DateTime CreatedAt { get; set; }
        public abstract DateTime UpdatedAt { get; set; }
        public abstract string Username { get; set; }
        public abstract string Password { get; set; }
        public abstract string ContactNumber { get; set; }
        public abstract string ContactAddress { get; set; }
        public abstract string ContactMail { get; set; }
    }
}