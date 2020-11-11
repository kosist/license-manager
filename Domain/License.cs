using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class License : BaseItem
    {
        [DisplayName("Issued by")]
        public User IssuedBy { get; set; }

        [DisplayName("Issue date")]
        [DataType(DataType.Date)]
        public DateTime IssueDate { get; set; } 
    }
}