using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PersonManagerApi.Models
{
    public class Person: Base
    {
        public string PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Email { get; set; }

        [Range(0, 9999999999, ErrorMessage = "Phone number must be a 10-digit number.")]
        public long? Phone { get; set; }

        // Foreign Key
        public int GenderTypeId { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public GenderType? GenderType { get; set; }
    }
}
