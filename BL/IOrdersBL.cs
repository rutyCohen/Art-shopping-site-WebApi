using Entities;
using System.Threading.Tasks;

namespace BL
{
    public interface IOrdersBL
    {
        Task<Order> Post(Order order);
    }
}