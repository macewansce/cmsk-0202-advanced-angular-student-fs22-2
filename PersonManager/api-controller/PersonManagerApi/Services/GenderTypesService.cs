using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Data;
using PersonManagerApi.Dtos;
using PersonManagerApi.Models;

namespace PersonManagerApi.Services
{
    public class GenderTypesService : IGenderTypesService
    {
        private readonly ApplicationDbContext _context;

        public GenderTypesService(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<List<GenderType>> GetGenderTypes()
        {
            var genderType = await _context.GenderTypes.ToListAsync();
            return genderType;
        }
    }
}
