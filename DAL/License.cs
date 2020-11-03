using System;

namespace DAL
{
    public class License : BaseItem
    {
        public User IssuedBy { get; set; }
        public DateTime IssueDate { get; set; } 
    }
}