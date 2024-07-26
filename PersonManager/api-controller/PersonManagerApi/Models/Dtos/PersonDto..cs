using System.ComponentModel.DataAnnotations;
using PersonManagerApi.Models.Entities;

namespace PersonManagerApi.Models.Dtos
{
    public class PersonDto : Base
    {
        public string PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Email { get; set; }

        [Range(0, 9999999999, ErrorMessage = "Phone number must be a 10-digit number.")]
        public long? Phone { get; set; }

        public int GenderTypeId { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
