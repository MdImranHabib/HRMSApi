using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HRMSApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace HRMSApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RentsController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public RentsController(HRMSDBContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rent>>> GetRent()
        {
            return await _context.Rents.Include(r => r.Flat).ToListAsync();
        }
      
        [HttpGet("{id}")]
        public async Task<ActionResult<Rent>> GetRent(int id)
        {
            //var rent = await _context.Rents.FindAsync(id);
            var rent = await _context.Rents.Include(r => r.Flat).SingleOrDefaultAsync(r => r.Id == id);

            if (rent == null)
            {
                return NotFound();
            }

            return rent;
        }

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
       
        [HttpPost]
        public async Task<ActionResult<Rent>> PostRent(Rent rent)
        {
            rent.Date = DateTime.Now;
            _context.Rents.Add(rent);
            await _context.SaveChangesAsync();

            var response = await _context.Rents.Include(r => r.Flat).SingleOrDefaultAsync(r => r.Id == rent.Id);
            return Ok(response);
            //return CreatedAtAction("GetRent", new { id = rent.Id }, rent);
        }
    
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
