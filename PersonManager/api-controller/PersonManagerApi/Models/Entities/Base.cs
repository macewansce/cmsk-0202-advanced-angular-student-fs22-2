

namespace PersonManagerApi.Models
{
    public class Base
    {
        public DateTime? DateCreated { get; set; }
        public bool IsDeleted { get; set; } = false;
    }

}
