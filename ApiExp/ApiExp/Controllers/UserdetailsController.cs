using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiExp.Models;

namespace ApiExp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserdetailsController : ControllerBase
    {
        private readonly WebApiContext _context;

        public UserdetailsController(WebApiContext context)
        {
            _context = context;
        }

        // GET: api/Userdetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Userdetail>>> GetUserdetails()
        {
            return await _context.Userdetails.ToListAsync();
        }

        // GET: api/Userdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Userdetail>> GetUserdetail(int id)
        {
            var userdetail = await _context.Userdetails.FindAsync(id);

            if (userdetail == null)
            {
                return NotFound();
            }

            return userdetail;
        }

        // PUT: api/Userdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserdetail(int id, Userdetail userdetail)
        {
            if (id != userdetail.Userid)
            {
                return BadRequest();
            }

            _context.Entry(userdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserdetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Userdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Userdetail>> PostUserdetail(Userdetail userdetail)
        {
            _context.Userdetails.Add(userdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserdetail", new { id = userdetail.Userid }, userdetail);
        }

        // DELETE: api/Userdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserdetail(int id)
        {
            var userdetail = await _context.Userdetails.FindAsync(id);
            if (userdetail == null)
            {
                return NotFound();
            }

            _context.Userdetails.Remove(userdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserdetailExists(int id)
        {
            return _context.Userdetails.Any(e => e.Userid == id);
        }
    }
}
