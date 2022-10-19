using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lesson1.Controllers

{


    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        IOrdersBL iOrderBL;
        IMapper imapper;

        public OrdersController(IOrdersBL iOrderBL, IMapper imapper)
        {
            this.iOrderBL = iOrderBL;
            this.imapper = imapper;
        }

        // POST api/<OrdersController>
        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post(OrderDTO order)
        {//[FromBody] 
            Order order1 = imapper.Map<Order>(order);
            //Order orders = await iOrderBL.Post(imapper.Map<Order>(order));
            Order orders = await iOrderBL.Post(order1);

            if (order != null)
                return imapper.Map<OrderDTO>(orders);
            return NoContent();
            //OrderDTO orderDTO = imapper.Map<Order,OrderDTO>(orders);
            //if (orderDTO != null)
            //{
            //    return Ok(orderDTO);
            //}
            //return NoContent();
        }
    }

}

