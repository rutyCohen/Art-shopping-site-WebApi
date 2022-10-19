using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class ProductDL : IProductDL
    {

        ArtAndCruftsContext ArtAndCruftsContext;
        public ProductDL(ArtAndCruftsContext ArtAndCruftsContext)
        {
            this.ArtAndCruftsContext = ArtAndCruftsContext;
        }
        public async Task<List<Product>> GetProduct()
        {
            return await ArtAndCruftsContext.Products.Select(e => e).ToListAsync();

        }

        public async Task<List<Product>> GetProductByCategory(int CategoryId)
        {
            return await ArtAndCruftsContext.Products.Where(p => p.CategoryId.Equals(CategoryId)).ToListAsync();

        }


    }
}
