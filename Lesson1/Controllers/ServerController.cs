using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using BL;
using Entities;
using AutoMapper;
using DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ex1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        IUserBL iuserBL;
        IMapper imapper;
        public ServerController(IUserBL iuserBL, IMapper imapper)
        {
            this.iuserBL = iuserBL;
            this.imapper = imapper;
        }

        

        // GET: api/<ValuesController>
        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<UserDTO>> Get(string email, string password)
        {
            User user = await iuserBL.Get(email, password);
            UserDTO userDTO = imapper.Map<User, UserDTO>(user);
            if (userDTO != null)
            {
                return userDTO;
            }
            return NoContent();
        }


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO user)
        {
            User user1 = imapper.Map<User>(user);
            User u = await iuserBL.Post(user1);
            UserDTO userDTO = imapper.Map<User, UserDTO>(u);

            return userDTO;
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDTO user)
        {
            User user1 = imapper.Map<User>(user);
            iuserBL.Put(id, user1);
        }

    }
}
