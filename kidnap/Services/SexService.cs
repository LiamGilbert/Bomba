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
            var list = await db.sex.FirstOrDefaultAsync(x => x.id_sex == id);
            if(list == null)
            {
                throw new Exception();
            }
            return list;
        }
    }
}
