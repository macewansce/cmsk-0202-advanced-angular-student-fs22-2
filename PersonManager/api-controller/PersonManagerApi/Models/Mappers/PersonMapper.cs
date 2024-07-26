using PersonManagerApi.Models.Dtos;
using PersonManagerApi.Models.Entities;

namespace PersonManagerApi.Models.Mappers
{
    public class PersonMapper
    {
        public static PersonDto ToDto(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var dto = new PersonDto
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Email = person.Email,
                Phone = person.Phone,
                GenderTypeId = person.GenderTypeId,
                IsDeleted = person.IsDeleted,
                DateCreated = person.DateCreated,

            };

            return dto;
        }

        public static List<PersonDto> ToDtos(List<Person> persons)
        {
            var personDtos = new List<PersonDto>();

            foreach (var person in persons)
            {
                var dto = ToDto(person);
                if (dto != null)
                {
                    personDtos.Add(dto);
                }
            }

            return personDtos;
        }

        public static Person ToEntity(PersonDto person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var entity = new Person
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Email = person.Email,
                Phone = person.Phone,
                GenderTypeId = person.GenderTypeId,
                IsDeleted = person.IsDeleted,
                DateCreated = person.DateCreated,

            };

            return entity;
        }


    }
}
