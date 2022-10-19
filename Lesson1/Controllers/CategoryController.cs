using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Category = Entities.Category;
using AutoMapper;
using DTO;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        ICategoryBL iCategoryBL;
        IMapper imapper;

        public CategoryController(ICategoryBL iCategoryBL, IMapper imapper)
        {
            this.iCategoryBL = iCategoryBL;
            this.imapper = imapper;
        }



        [HttpGet]
        public async Task<ActionResult<List<CategoryDTO>>> GetCategory()
        {
            List<Category> categories = await iCategoryBL.GetCategory();
            List<CategoryDTO> categoryDTO = imapper.Map<List<Category>, List<CategoryDTO>>(categories);
            if (categoryDTO != null)
            {
                return Ok(categoryDTO);
            }
            return NoContent();
        }


    }
}
