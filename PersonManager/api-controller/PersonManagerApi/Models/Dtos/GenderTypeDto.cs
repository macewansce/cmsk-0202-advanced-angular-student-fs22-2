using System.Text.Json.Serialization;

namespace PersonManagerApi.Dtos
{
    public class GenderTypeDto
    {
        public int GenderTypeId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
