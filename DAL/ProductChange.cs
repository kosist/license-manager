using System;

namespace DAL
{
    public class ProductChange : BaseItem
    {
        public DateTime UpdateDate { get; set; }
        public string Comment { get; set; }
    }
}