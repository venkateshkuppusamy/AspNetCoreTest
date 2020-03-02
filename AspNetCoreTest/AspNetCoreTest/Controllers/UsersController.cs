﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> Users = new List<User>();
        public UsersController()
        {
            if (!Users.Any())
            {
                User u1 = new User() { ID = 1, Name = "venki", Address = "Velachery", PhoneNo = "+91" };
                User u2 = new User() { ID = 2, Name = "Mahi", Address = "Neelankarai", PhoneNo = "+91" };
                User u3 = new User() { ID = 3, Name = "Arun", Address = "Hydreabad", PhoneNo = "+91" };
                Users.Add(u1);
                Users.Add(u2);
                Users.Add(u3);
            }
        }

        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var user = Users.FirstOrDefault(f => f.ID == id);
            if (user != null)
                return Ok(user);
            else
                return NotFound();
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if (Users.Any(a => a.ID == user.ID))
                return UnprocessableEntity("User ID already taken");
            else
            {
                Users.Add(user);
                return Created($"api/Users/{user.ID}", user);
            }
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User userModel)
        {
            if (Users.Any(a => a.ID == id)) {
                var user = Users.First(f => f.ID == id);
                user.Name = userModel.Name;
                user.Address = userModel.Address;
                user.PhoneNo = userModel.PhoneNo;
                return Ok(user);
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (Users.Any(a => a.ID == id))
            {
                Users.Remove(Users.First(f => f.ID == id));
                return NoContent();
            }
            else
                return NotFound();

        }
    }
}