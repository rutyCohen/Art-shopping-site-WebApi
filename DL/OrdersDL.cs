using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class OrdersDL : IOrdersDL
    {

        ArtAndCruftsContext ArtAndCruftsContext;
        public OrdersDL(ArtAndCruftsContext ArtAndCruftsContext)
        {
            this.ArtAndCruftsContext = ArtAndCruftsContext;
        }

        public async Task<Order> Post(Order order)
        {
            await ArtAndCruftsContext.Orders.AddAsync(order);
            await ArtAndCruftsContext.SaveChangesAsync();
            return order;

        }
    }
}
