using System;

namespace SouthernCross.Domain.Models
{
    public class Member
    {
        public int Id { get; set; }
        public int PolicyNumber { get; set; }
        public int CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
