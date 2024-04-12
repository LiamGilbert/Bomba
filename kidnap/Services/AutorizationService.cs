using kidnap.Data;
using kidnap.DTO.Autorization;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class AutorizationService
    {
        public async Task<List<AutorizationEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.autorization.Include(x => x.person).ThenInclude(x=>x.role).ToListAsync();
            return list;
        }

        public async Task<AutorizationEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.autorization.Include(x => x.person).
                ThenInclude(x => x.role).
                FirstOrDefaultAsync(x => x.id_autorization == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }
        public async Task<AutorizationEntity> Login(LoginDTO dto)
        {
            using var db = new DataContext();
            var item = await db.autorization
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
        public async Task<AutorizationEntity> Create(CreateAutorizationDTO createAutorization)
        {
            using var db = new DataContext();
            var item = new AutorizationEntity()
            {
                id_person = createAutorization.id_person,
                login = createAutorization.login,
                password = createAutorization.password
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AutorizationEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.autorization.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
