using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class CategoryDL : ICategoryDL
    {

        ArtAndCruftsContext ArtAndCruftsContext;
        public CategoryDL(ArtAndCruftsContext ArtAndCruftsContext)
        {
            this.ArtAndCruftsContext = ArtAndCruftsContext;
        }
        public async Task<List<Category>> GetCategory()
        {
            return await ArtAndCruftsContext.Categories.Select(e => e).ToListAsync();
        }

    }
}
