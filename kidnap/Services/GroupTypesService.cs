using kidnap.Data;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class GroupTypesService
    {
        public async Task<List<GroupTypesEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.grouptypes.Include(x=>x.group_type).ToListAsync();
            return list;
        }

        public async Task<GroupTypesEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.grouptypes.Include(x => x.group_type).
                FirstOrDefaultAsync(x => x.id_grouptype == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }
    }
}
