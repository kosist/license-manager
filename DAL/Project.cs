using System.Collections.Generic;

namespace DAL
{
    public class Project : BaseItem
    {
        public Customer Customer { get; set; }
        public List<Product> SwProducts { get; set; }
    }
}