using Entities;
using System.Threading.Tasks;

namespace DL
{
    public interface IOrdersDL
    {
        Task<Order> Post(Order order);
    }
}