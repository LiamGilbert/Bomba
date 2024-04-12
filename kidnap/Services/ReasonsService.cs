using kidnap.Data;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class ReasonsService
    {
        public async Task<List<ReasonsEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.reasons.ToListAsync();
            return list;
        }

        public async Task<ReasonsEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.reasons.FirstOrDefaultAsync(x => x.id_reason == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }
    }
}
