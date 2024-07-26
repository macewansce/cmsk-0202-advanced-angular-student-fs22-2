using PersonManagerApi.Models.Entities;

namespace PersonManagerApi.Services
{
    public interface IGenderTypesService
    {
        Task<List<GenderType>> GetAll();
        Task<GenderType?> GetOne(int id);
        Task<GenderType> Add(GenderType genderType);
        Task<GenderType?> Update(GenderType genderType);
        Task<GenderType?> Delete(int id);
    }
}
