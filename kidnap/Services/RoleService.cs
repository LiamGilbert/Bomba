using kidnap.Data;
using kidnap.DTO.Autorization;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;
using Mysqlx.Resultset;

namespace kidnap.Services
{
    public class RoleService
    {
        public async Task<List<RoleEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.roles.ToListAsync();
            return list;
        }

        public async Task<RoleEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.roles.FirstOrDefaultAsync(x => x.id_role == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }
    }
}
