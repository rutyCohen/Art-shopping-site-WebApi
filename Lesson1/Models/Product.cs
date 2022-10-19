using System;
using System.Collections.Generic;

#nullable disable

namespace Lesson1.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public double ProdPrice { get; set; }
        public string ProdDesc { get; set; }
        public int CategoryId { get; set; }
        public string ProdImg { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
