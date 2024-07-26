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
    public class GenderTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IGenderTypesService _service;

        public GenderTypesController(ApplicationDbContext context, IGenderTypesService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/GenderTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenderTypeDto>>> GetGenderTypes()
        {
          if (_context.GenderTypes == null)
          {
              return NotFound();
          }

         var genderTypes = await _service.GetAll();

          return GenderTypeMapper.ToDtos(genderTypes);
        }

        // GET: api/GenderTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenderTypeDto>> GetGenderType(int id)
        {
            var genderType = await _service.GetOne(id);

            if (genderType == null)
            {
                return NotFound();
            }

            return GenderTypeMapper.ToDto(genderType);
        }

        // PUT: api/GenderTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenderType(int id, GenderTypeDto genderType)
        {
            if (id != genderType.GenderTypeId)
            {
                return BadRequest();
            }

            var genderTypeToBeUpdated = await _service.Update(GenderTypeMapper.ToEntity(genderType));

            if (genderTypeToBeUpdated == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/GenderTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GenderTypeDto>> PostGenderType(GenderTypeDto genderType)
        {
            var genderTypeToAdd = GenderTypeMapper.ToEntity(genderType);

            var addedGenderType = await _service.Add(genderTypeToAdd);

            var addedGenderTypeDto = GenderTypeMapper.ToDto(addedGenderType);

            return CreatedAtAction("GetGenderType", new { id = addedGenderType.GenderTypeId }, addedGenderTypeDto);
        }

        // DELETE: api/GenderTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenderType(int id)
        {
            var genderTypeToBeDelete = await _service.Delete(id);

            if (genderTypeToBeDelete == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
