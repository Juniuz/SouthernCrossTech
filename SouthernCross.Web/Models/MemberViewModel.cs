using System;

namespace SouthernCross.Web.Models
{
    public class MemberViewModel
    {
        public int PolicyNumber { get; set; }
        public int CardNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
