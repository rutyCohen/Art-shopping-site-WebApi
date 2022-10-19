using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface ICategoryDL
    {
        Task<List<Category>> GetCategory();


    }
}