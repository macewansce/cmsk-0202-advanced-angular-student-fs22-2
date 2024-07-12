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
        public int Phone { get; set; }

        // Foreign Key
        public int GenderTypeId { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public GenderType? GenderType { get; set; }
    }
}
