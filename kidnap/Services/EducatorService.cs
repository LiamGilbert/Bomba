using kidnap.Data;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class EducatorService
    {
        public async Task<List<EducatorEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.educators.Include(x => x.SexEntity).ToListAsync();
            return list;
        }

        public async Task<EducatorEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.educators.Include(x => x.SexEntity).FirstOrDefaultAsync(x => x.Id_educator == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<EducatorEntity> Create(EducatorEntity educator)
        {
            using var db = new DataContext();
            var list = db.educators.Add(educator).Entity;
            await db.SaveChangesAsync();
            return list;
        }

        public async Task<EducatorEntity> Update(EducatorEntity educator)
        {
            using var db = new DataContext();
            var list = db.educators.Update(educator).Entity;
            await db.SaveChangesAsync();
            return list;
        }

        public async Task<EducatorEntity> Delete(int id)
        {
            using var db = new DataContext();
            var list = db.educators.Remove(await FindById(id)).Entity;
            await db.SaveChangesAsync();
            return list;
        }
    }
}
