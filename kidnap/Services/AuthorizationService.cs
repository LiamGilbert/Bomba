using kidnap.Data;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;
using kidnap.DTO.Autorization;

namespace kidnap.Services
{
    public class AuthorizationService
    {
        public async Task<List<AuthorizationEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.authorization.Include(x => x.person).ThenInclude(x=>x.role).ToListAsync();
            return list;
        }

        public async Task<AuthorizationEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.authorization.Include(x => x.person).
                ThenInclude(x => x.role).
                FirstOrDefaultAsync(x => x.id_autorization == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }
        public async Task<AuthorizationEntity> Login(LoginDTO dto)
        {
            using var db = new DataContext();
            var item = await db.authorization
                .Include(x => x.person)
                .ThenInclude(x => x.role)
                .FirstOrDefaultAsync(x => x.login == dto.login);
            
            if (item == null)
            {
                throw new Exception();
            }

            if (!item.password.Equals(dto.password))
            {
                throw new Exception();
            }

            return item;
        }
        public async Task<AuthorizationEntity> Create(CreateAuthorizationDTO createAutorization)
        {
            using var db = new DataContext();
            var item = new AuthorizationEntity()
            {
                id_person = createAutorization.id_person,
                login = createAutorization.login,
                password = createAutorization.password
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AuthorizationEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.authorization.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
