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
    public class ResidentFlatsController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public ResidentFlatsController(HRMSDBContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResidentFlat>>> GetResidentFlat()
        {
            return await _context.ResidentFlats
                .Include(rf => rf.Flat)
                .Include(rf => rf.Resident)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResidentFlat>> GetResidentFlat(int id)
        {
            //var residentFlat = await _context.ResidentFlats.FindAsync(id);
            var residentFlat = await _context.ResidentFlats
                .Include(rf => rf.Flat)
                .Include(rf => rf.Resident)
                .SingleOrDefaultAsync(rf => rf.Id == id);

            if (residentFlat == null)
            {
                return NotFound();
            }

            return residentFlat;
        }
     
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResidentFlat(int id, ResidentFlat residentFlat)
        {
            if (id != residentFlat.Id)
            {
                return BadRequest();
            }

            _context.Entry(residentFlat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentFlatExists(id))
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
        public async Task<ActionResult<ResidentFlat>> PostResidentFlat(ResidentFlat residentFlat)
        {
            _context.ResidentFlats.Add(residentFlat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResidentFlat", new { id = residentFlat.Id }, residentFlat);
        }
      
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResidentFlat>> DeleteResidentFlat(int id)
        {
            var residentFlat = await _context.ResidentFlats.FindAsync(id);
            if (residentFlat == null)
            {
                return NotFound();
            }

            _context.ResidentFlats.Remove(residentFlat);
            await _context.SaveChangesAsync();

            return residentFlat;
        }

        private bool ResidentFlatExists(int id)
        {
            return _context.ResidentFlats.Any(e => e.Id == id);
        }
    }
}
