using kidnap.Data;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class SexService
    {
        public async Task<List<SexEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.sex.ToListAsync();
            return list;
        }

        public async Task<SexEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.sex.FirstOrDefaultAsync(x => x.Id_sex == id);
            if(list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<SexEntity> Create(SexEntity sex)
        {
            using var db = new DataContext();
            var list = db.sex.Add(sex).Entity;
            await db.SaveChangesAsync();
            return list;
        }

        public async Task<SexEntity> Update(SexEntity sex)
        {
            using var db = new DataContext();
            var list = db.sex.Update(sex).Entity;
            await db.SaveChangesAsync();
            return list;
        }

        public async Task<SexEntity> Delete(int id)
        {
            using var db = new DataContext();
            var list = db.sex.Remove(await FindById(id)).Entity;
            await db.SaveChangesAsync();
            return list;
        }
    }
}
