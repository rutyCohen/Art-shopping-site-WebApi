﻿using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface ICategoryBL
    {
        public Task<List<Category>> GetCategory();

    }

}