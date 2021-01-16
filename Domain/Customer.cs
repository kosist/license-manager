using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer : BaseItem

    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string Address { get; set; }

        private ICollection<Project> Projects { get; set; }

    }
}