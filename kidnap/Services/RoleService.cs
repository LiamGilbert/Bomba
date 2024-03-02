using kidnap.Data;
using kidnap.DTO;
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
            var list = await db.roles.FirstOrDefaultAsync(x => x.Id_role == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<RoleEntity> Create(RoleEntity role)
        {
            using var db = new DataContext();
            var list = db.roles.Add(role).Entity;
            await db.SaveChangesAsync();
            return list;
        }

        public async Task<RoleEntity> Update(RoleEntity role)
        {
            using var db = new DataContext();
            var list = db.roles.Update(role).Entity;
            await db.SaveChangesAsync();
            return list;
        }

        public async Task<RoleEntity> Delete(int id)
        {
            using var db = new DataContext();
            var list = db.roles.Remove(await FindById(id)).Entity;
            await db.SaveChangesAsync();
            return list;
        }

        public async Task<RoleEntity> Login(LoginDTO role)
        {
            using var db = new DataContext();
            var lp = await db.roles.FirstOrDefaultAsync(x => x.Login.ToLower() == role.Login.ToLower());
            if (lp == null)
            {
                throw new Exception();
            }
            if(lp.Password != role.Password)
            {
                throw new Exception();
            }
            return lp;
        }
    }
}
