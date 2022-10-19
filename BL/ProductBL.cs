using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ProductBL : IProductBL
    {
        IProductDL iProductDL;
        public ProductBL(IProductDL iProductDL)
        {
            this.iProductDL = iProductDL; ;
        }
        public async Task<List<Product>> GetProduct()
        {
            return await iProductDL.GetProduct();
        }
        public async Task<List<Product>> GetProductByCategory(int CategoryId)
        {
            return await iProductDL.GetProductByCategory(CategoryId);
        }


    }
}
