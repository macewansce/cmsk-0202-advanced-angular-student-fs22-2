using Microsoft.AspNetCore.Mvc;
using PersonManagerApi.Dtos;
using PersonManagerApi.Models;

namespace PersonManagerApi.Services
{
    public interface IGenderTypesService
    {
        Task<List<GenderType>> GetGenderTypes();
    }
}
