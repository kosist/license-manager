using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Project : BaseItem
    {
        [Required]
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public List<Product> SwProducts { get; set; }
    }
}