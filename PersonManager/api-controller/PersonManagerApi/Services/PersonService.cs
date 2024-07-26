//using Microsoft.EntityFrameworkCore;
//using PersonManagerApi.Data;
//using PersonManagerApi.Models.Entities;

//namespace PersonManagerApi.Services
//{
//    public class GenderTypesService : IGenderTypesService
//    {
//        private readonly ApplicationDbContext _context;

//        public GenderTypesService(ApplicationDbContext context) {
//            _context = context;
//        }

//        public async Task<List<GenderType>> GetAll()
//        {
//            var genderType = await _context.GenderTypes.ToListAsync();
//            return genderType;
//        }

//        public async Task<GenderType?> GetOne(int id)
//        {
//            var genderType = await _context.GenderTypes.FindAsync(id);

//            return genderType;
//        }

//        public async Task<GenderType> Add(GenderType genderType)
//        {
//            genderType.DateCreated = DateTime.Now;
//            genderType.IsDeleted = false;

//            _context.GenderTypes.Add(genderType);

//            await _context.SaveChangesAsync();

//            return genderType;
//        }

//        public async Task<GenderType?> Update(GenderType genderType)
//        {
//            var genderTypeToBeUpdated = await GetOne(genderType.GenderTypeId);

//            if (genderTypeToBeUpdated == null) return null;

//            genderTypeToBeUpdated.Name = genderType.Name;

//            await _context.SaveChangesAsync();

//            return genderTypeToBeUpdated;
//        }

//        public async Task<GenderType?> Delete(int id)
//        {
//            var genderTypeToBeDelete = await GetOne(id);

//            if (genderTypeToBeDelete == null) return null;

//            genderTypeToBeDelete.IsDeleted = true;

//            await _context.SaveChangesAsync();

//            return genderTypeToBeDelete;
//        }
//    }
//}
