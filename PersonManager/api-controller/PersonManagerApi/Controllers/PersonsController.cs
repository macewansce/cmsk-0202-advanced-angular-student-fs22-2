using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Data;
using PersonManagerApi.Models.Dtos;
using PersonManagerApi.Models.Mappers;
using PersonManagerApi.Services;

namespace PersonManagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonsService _service;

        public PersonsController(ApplicationDbContext context, IPersonsService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Persons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDto>>> GetPersons()
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }

            var persons = await _service.GetAll();

            return PersonMapper.ToDtos(persons);
        }

        // GET: api/Persons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDto>> GetPerson(string id)
        {
            var person = await _service.GetOne(id);

            if (person == null)
            {
                return NotFound();
            }

            return PersonMapper.ToDto(person);
        }

        // PUT: api/Persons/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(string id, PersonDto person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            var personToBeUpdated = await _service.Update(PersonMapper.ToEntity(person));

            if (personToBeUpdated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Persons
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonDto>> PostPerson(PersonDto person)
        {
            var personToAdd = PersonMapper.ToEntity(person);

            var addedPerson = await _service.Add(personToAdd);

            var addedPersonDto = PersonMapper.ToDto(addedPerson);

            return CreatedAtAction("GetPerson", new { id = addedPerson.PersonId }, addedPersonDto);
        }

        // DELETE: api/Persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(string id)
        {
            var personToBeDelete = await _service.Delete(id);

            if (personToBeDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
