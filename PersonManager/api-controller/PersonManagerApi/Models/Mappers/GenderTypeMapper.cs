using PersonManagerApi.Models.Dtos;
using PersonManagerApi.Models.Entities;

namespace PersonManagerApi.Models.Mappers
{
    public class GenderTypeMapper
    {
        public static GenderTypeDto ToDto(GenderType genderType)
        {
            if (genderType == null)
            {
                throw new ArgumentNullException(nameof(genderType));
            }

            var dto = new GenderTypeDto
            {
                GenderTypeId = genderType.GenderTypeId,
                Name = genderType.Name,
                IsDeleted = genderType.IsDeleted,
                DateCreated = genderType.DateCreated,

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

        public static GenderType ToEntity(GenderTypeDto genderType)
        {
            if (genderType == null)
            {
                throw new ArgumentNullException(nameof(genderType));
            }

            var entity = new GenderType
            {
                GenderTypeId = genderType.GenderTypeId,
                Name = genderType.Name,
                IsDeleted = genderType.IsDeleted,
                DateCreated = genderType.DateCreated,

            };

            return entity;
        }


    }
}
