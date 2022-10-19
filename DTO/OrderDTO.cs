

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class OrderDTO
    {
        public OrderDTO()
        {
            OrderItems = new HashSet<OrderItemDTO>();
        }
        public int OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public double OrderSum { get; set; }
        public int UserId { get; set; }
        public int? OrderItem { get; set; }
        public virtual ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
