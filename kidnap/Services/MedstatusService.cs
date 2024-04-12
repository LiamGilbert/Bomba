using kidnap.Data;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class MedstatusService
    {
        public async Task<List<MedstatusEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.medstatus.ToListAsync();
            return list;
        }

        public async Task<MedstatusEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.medstatus.FirstOrDefaultAsync(x => x.id_medstatus == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }
    }
}
