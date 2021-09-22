using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSApi.Models;

namespace HRMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public RentsController(HRMSDBContext context)
        {
            _context = context;
        }

        // GET: api/Rents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent>>> GetRent()
        {
            return await _context.Rents.ToListAsync();
        }

        // GET: api/Rents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRent(int id)
        {
            var rent = await _context.Rents.FindAsync(id);

            if (rent == null)
            {
                return NotFound();
            }

            return rent;
        }

        // PUT: api/Rents/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRent(int id, Rent rent)
        {
            if (id != rent.Id)
            {
                return BadRequest();
            }

            _context.Entry(rent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentExists(id))
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

        // POST: api/Rents
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rent>> PostRent(Rent rent)
        {
            _context.Rents.Add(rent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRent", new { id = rent.Id }, rent);
        }

        // DELETE: api/Rents/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rent>> DeleteRent(int id)
        {
            var rent = await _context.Rents.FindAsync(id);
            if (rent == null)
            {
                return NotFound();
            }

            _context.Rents.Remove(rent);
            await _context.SaveChangesAsync();

            return rent;
        }

        private bool RentExists(int id)
        {
            return _context.Rents.Any(e => e.Id == id);
        }
    }
}
