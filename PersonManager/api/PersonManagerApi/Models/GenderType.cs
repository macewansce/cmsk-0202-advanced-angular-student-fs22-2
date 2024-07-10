using System.Text.Json.Serialization;

namespace PersonManagerApi.Models
{
    public class GenderType
    {
        public int GenderTypeId { get; set; }
        public string Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Navigation Property
        //[JsonIgnore]
        //public ICollection<Course>? Courses { get; set; }
    }
}
