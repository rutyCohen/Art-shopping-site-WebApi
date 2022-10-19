using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IProductDL
    {
        Task<List<Product>> GetProduct();
        Task<List<Product>> GetProductByCategory(int CategoryId);
    }
}