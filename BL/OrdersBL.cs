
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DL;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace BL
{

    public class OrdersBL : IOrdersBL
    {
        IOrdersDL iOrdersDL;
        ArtAndCruftsContext ArtAndCruftsContext;
        ILogger ILogger;
        public OrdersBL(IOrdersDL iOrdersDL, ArtAndCruftsContext ArtAndCruftsContext, ILogger<OrdersBL> ILogger)
        {
            this.iOrdersDL = iOrdersDL;
            this.ArtAndCruftsContext = ArtAndCruftsContext;
            this.ILogger = ILogger;
        }

        public async Task<Order> Post(Order Order)
        {
            checkSum(Order);
            var Order1 = await iOrdersDL.Post(Order);
            if (Order1 == null)
                return null;
            return Order1;


        }
        public async void checkSum(Order Order)
        {
            using (var context = new ArtAndCruftsContext())
            {
                double sum = 0;
                foreach (var product in Order.OrderItems)
                {
                    Product prod = await context.Products.Where(p => p.ProdId == product.ProductId).FirstOrDefaultAsync();
                    double quntity = (double)Order.OrderItems.Where(p => p.ProductId == product.ProductId).FirstOrDefault().Quantity;
                    sum += prod.ProdPrice * quntity;
                }
                if (sum != Order.OrderSum)
                {
                    ILogger.LogInformation("the user " + Order.UserId + " try to change the price of the order,please note!!");
                    Order.OrderSum = sum;
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
