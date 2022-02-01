﻿using DevDojo.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevDojo.Server
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly ILogger<ItemController> _logger;
        private readonly AppDbContext _context;

        public ItemController(ILogger<ItemController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = _context.Items.ToList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var result = _context.Items.FirstOrDefault(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] TaskItem newItem)
        {
            var result = await _context.Items.AddAsync(newItem);
            await _context.SaveChangesAsync();
            return Ok("");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {

            if (id < 1)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var User = _context.Items.FirstOrDefault(x => x.Id == id);

                if (User == null)
                {
                    return BadRequest("Submitted data is invalid");
                }

                _context.Items.Remove(User);
                await _context.SaveChangesAsync();
                return Ok("");


            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }

        }


        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] TaskItem chosenItem)
        {
            var User = _context.Items.FirstOrDefault(x => x.Id == chosenItem.Id);
            if (User == null)
            {
                return BadRequest("Submitted data is invalid");
            }
            User.Name = chosenItem.Name;
            User.Status = chosenItem.Status;

            await _context.SaveChangesAsync();
            return Ok("");
        }
    }
}
