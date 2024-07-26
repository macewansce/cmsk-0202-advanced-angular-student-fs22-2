using System.Text.Json.Serialization;

namespace PersonManagerApi.Models.Entities
{
    public class GenderType : Base
    {
        public int GenderTypeId { get; set; }
        public string Name { get; set; }


        // Navigation Property
        [JsonIgnore]
        public ICollection<Person>? Persons { get; set; }
    }
}
