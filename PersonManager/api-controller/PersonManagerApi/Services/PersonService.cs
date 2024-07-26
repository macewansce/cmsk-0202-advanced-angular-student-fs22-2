using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Data;
using PersonManagerApi.Models.Entities;

namespace PersonManagerApi.Services
{
    public class PersonsService : IPersonsService
    {
        private readonly ApplicationDbContext _context;

        public PersonsService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<Person>> GetAll()
        {
            var person = await _context.Persons.ToListAsync();
            return person;
        }

        public async Task<Person?> GetOne(string id)
        {
            var person = await _context.Persons.FindAsync(id);

            return person;
        }

        public async Task<Person> Add(Person person)
        {
            person.PersonId = Guid.NewGuid().ToString();
            person.DateCreated = DateTime.Now;
            person.IsDeleted = false;

            _context.Persons.Add(person);

            await _context.SaveChangesAsync();

            return person;
        }

        public async Task<Person?> Update(Person person)
        {
            var personToBeUpdated = await GetOne(person.PersonId);

            if (personToBeUpdated == null) return null;

            personToBeUpdated.FirstName = person.FirstName;
            personToBeUpdated.LastName = person.LastName;
            personToBeUpdated.DateOfBirth = person.DateOfBirth;
            personToBeUpdated.Email = person.Email;
            personToBeUpdated.Phone = person.Phone;
            personToBeUpdated.GenderTypeId = person.GenderTypeId;

            await _context.SaveChangesAsync();

            return personToBeUpdated;
        }

        public async Task<Person?> Delete(string id)
        {
            var personToBeDelete = await GetOne(id);

            if (personToBeDelete == null) return null;

            personToBeDelete.IsDeleted = true;

            await _context.SaveChangesAsync();

            return personToBeDelete;
        }
    }
}
