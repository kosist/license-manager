using System.Collections.Generic;

namespace Domain
{
    public class Project : BaseItem
    {
        public string Name { get; set; }
        public Customer Customer { get; set; }
        public List<Product> SwProducts { get; set; }
    }
}