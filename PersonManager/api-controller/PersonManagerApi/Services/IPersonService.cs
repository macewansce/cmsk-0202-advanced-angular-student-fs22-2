using PersonManagerApi.Models.Entities;

namespace PersonManagerApi.Services
{
    public interface IPersonsService
    {
        Task<List<Person>> GetAll();
        Task<Person?> GetOne(string id);
        Task<Person> Add(Person person);
        Task<Person?> Update(Person person);
        Task<Person?> Delete(string id);
    }
}
