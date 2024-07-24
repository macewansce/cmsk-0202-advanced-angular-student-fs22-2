using System.Text.Json.Serialization;
using PersonManagerApi.Dtos;

namespace PersonManagerApi.Models
{
    public class GenderTypeMapper
    {
        public static GenderTypeDto? ToDto(GenderType genderType)
        {
            if (genderType == null)
            {
                return null;
            }

            var dto = new GenderTypeDto
            {
                GenderTypeId = genderType.GenderTypeId,
                Name = genderType.Name,
                IsDeleted = genderType.IsDeleted,
            };

            return dto;
        }

        public static List<GenderTypeDto> ToDtos(List<GenderType> genderTypes)
        {
            var genderTypeDtos = new List<GenderTypeDto>();

            foreach (var genderType in genderTypes)
            {
                var dto = ToDto(genderType);
                if (dto != null)
                {
                    genderTypeDtos.Add(dto);
                }
            }

            return genderTypeDtos;
        }


    }
}
