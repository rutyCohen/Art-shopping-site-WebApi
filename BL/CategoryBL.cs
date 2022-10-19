using DL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class CategoryBL : ICategoryBL
    {
        ICategoryDL iCategoryDL;
        public CategoryBL(ICategoryDL iCategoryDL)
        {
            this.iCategoryDL = iCategoryDL; ;
        }
        public async Task<List<Category>> GetCategory()
        {
            return await iCategoryDL.GetCategory();
        }


    }
}
