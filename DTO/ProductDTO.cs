using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        public ProductDTO()
        {
            //OrderItems = new HashSet<OrderItem>();
        }
        public int ProdId { get; set; }
        public string ProdName { get; set; }
        public double ProdPrice { get; set; }
        public string ProdDesc { get; set; }
        public int CategoryId { get; set; }
        public string ProdImg { get; set; }

    }
}
