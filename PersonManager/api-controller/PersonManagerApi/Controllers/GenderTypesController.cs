using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Data;
using PersonManagerApi.Models;

namespace PersonManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public GenderTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/GenderTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderType>>> GetGenderTypes()
        {
          if (_context.GenderTypes == null)
          {
              return NotFound();
          }
            return await _context.GenderTypes.ToListAsync();
        }

        // GET: api/GenderTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenderType>> GetGenderType(int id)
        {
          if (_context.GenderTypes == null)
          {
              return NotFound();
          }
            var genderType = await _context.GenderTypes.FindAsync(id);

            if (genderType == null)
            {
                return NotFound();
            }

            return genderType;
        }

        // PUT: api/GenderTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenderType(int id, GenderType genderType)
        {
            if (id != genderType.GenderTypeId)
            {
                return BadRequest();
            }

            var genderTypeToBeUpdated = await _context.GenderTypes.FindAsync(id);

            if (genderTypeToBeUpdated == null)
            {
                return NotFound();
            }

            genderTypeToBeUpdated.Name = genderType.Name;

            _context.Entry(genderTypeToBeUpdated).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/GenderTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenderType>> PostGenderType(GenderType genderType)
        {
          if (_context.GenderTypes == null)
          {
              return Problem("Entity set 'ApplicationDbContext.GenderTypes'  is null.");
          }

            genderType.DateCreated = DateTime.Now;
            genderType.IsDeleted = false;

            _context.GenderTypes.Add(genderType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenderType", new { id = genderType.GenderTypeId }, genderType);
        }

        // DELETE: api/GenderTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenderType(int id)
        {
            var genderType = await _context.GenderTypes.FindAsync(id);

            if (genderType == null)
            {
                return NotFound();

            }
            
            genderType.IsDeleted = true;

            _context.Entry(genderType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
               
                    throw;
            }

            return NoContent();
        }

        private bool GenderTypeExists(int id)
        {
            return (_context.GenderTypes?.Any(e => e.GenderTypeId == id)).GetValueOrDefault();
        }
    }
}
