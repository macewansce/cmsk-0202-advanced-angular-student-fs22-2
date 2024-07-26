using System.ComponentModel.DataAnnotations;

namespace PersonManagerApi.Models.Dtos
{
    public class GenderTypeDto
    {
        public int GenderTypeId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(10)]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DateCreated { get; set; }
    }
}
