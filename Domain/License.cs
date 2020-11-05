using System;

namespace Domain
{
    public class License : BaseItem
    {
        public User IssuedBy { get; set; }
        public DateTime IssueDate { get; set; } 
    }
}