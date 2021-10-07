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
    public class ResidentsController : ControllerBase
    {
        private readonly HRMSDBContext _context;

        public ResidentsController(HRMSDBContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResident()
        {
            return await _context.Residents.ToListAsync();
        }
       
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResident(int id)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
            {
                return NotFound();
            }

            return resident;
        }
    
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident(int id, Resident resident)
        {
            if (id != resident.Id)
            {
                return BadRequest();
            }

            _context.Entry(resident).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
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
        public async Task<ActionResult<Resident>> PostResident(Resident resident)
        {           
            _context.Residents.Add(resident);            
            await _context.SaveChangesAsync();

            User user = new User()
            {
                UserName = resident.ContactNo,
                Password = "12345",
                ResidentId = resident.Id,
                CreateBy = "Admin",
                CreateDate = System.DateTime.Now,
                UpdateBy = "",
                UpdateDate = null,
                Deleted = false
            };
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResident", new { id = resident.Id }, resident);
        }
    
        [HttpDelete("{id}")]
        public async Task<ActionResult<Resident>> DeleteResident(int id)
        {
            var resident = await _context.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound();
            }

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();

            return resident;
        }

        private bool ResidentExists(int id)
        {
            return _context.Residents.Any(e => e.Id == id);
        }
    }
}
