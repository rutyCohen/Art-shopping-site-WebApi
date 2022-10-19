using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IProductBL
    {
        Task<List<Product>> GetProduct();
        Task<List<Product>> GetProductByCategory(int CategoryId);
    }
}