using AutoMapper;
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        IProductBL iProductBL;
        IMapper imapper;


        public ProductController(IProductBL iProductBL, IMapper imapper)
        {
            this.iProductBL = iProductBL;
            this.imapper = imapper;
        }


        // GET: api/<ProductController>
        [HttpGet]

        public async Task<ActionResult<List<ProductDTO>>> GetProduct()
        {
            List<Product> products = await iProductBL.GetProduct();
            List<ProductDTO> productDTO = imapper.Map<List<Product>, List<ProductDTO>>(products);
            if (productDTO != null)
            {
                return Ok(productDTO);
            }
            return NoContent();
        }
        // GET api/<ProductController>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<List<ProductDTO>>> GetProductByCategory(int id)
        {
            List<Product> products = await iProductBL.GetProductByCategory(id);
            List<ProductDTO> productDTO = imapper.Map<List<Product>, List<ProductDTO>>(products);
            if (productDTO != null)
            {
                return Ok(productDTO);
            }
            return NoContent();
        }

    }
}
