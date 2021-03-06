using DevDojo.Shared;
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
    public class PersonController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly AppDbContext _context;

        public PersonController(ILogger<ItemsController> logger, AppDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            var result = _context.Persons.ToList();
            return Ok(result);
        }

        [HttpGet("last")]
        public async Task<IActionResult> GetItem()
        {
            var result = _context.Items.LastOrDefault();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] Result result)
        {
            Person person = new Person()
            {
                FirstName = result.name.first,
                LastName = result.name.last,
                Age = result.dob.age,
                Location = result.location.city,
            };
           
            var personadded = await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return Ok("");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
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
        public async Task<IActionResult> UpdateItem([FromBody] TaskItem chosenItem)
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
