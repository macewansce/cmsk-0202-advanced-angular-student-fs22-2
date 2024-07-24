using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Data;
using PersonManagerApi.Models;

namespace PersonManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {

            return await _context.Persons.ToListAsync();
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(string id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(string id, Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            var personToBeUpdated = await _context.Persons.FindAsync(id);

            if (personToBeUpdated == null)
            {
                return NotFound();
            }

            personToBeUpdated.FirstName = person.FirstName;
            personToBeUpdated.LastName = person.LastName;
            personToBeUpdated.DateOfBirth = person.DateOfBirth;
            personToBeUpdated.Email = person.Email;
            personToBeUpdated.Phone = person.Phone;
            personToBeUpdated.GenderTypeId = person.GenderTypeId;

    

        _context.Entry(personToBeUpdated).State = EntityState.Modified;

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

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
          if (_context.Persons == null)
          {
              return Problem("Entity set 'ApplicationDbContext.Persons'  is null.");
          }

            person.PersonId = Guid.NewGuid().ToString();
            person.DateCreated = DateTime.Now;
            person.IsDeleted = false;

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(string id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();

            }
            
            person.IsDeleted = true;

            _context.Entry(person).State = EntityState.Modified;

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

        private bool PersonExists(string id)
        {
            return (_context.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
