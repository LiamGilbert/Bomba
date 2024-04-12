using kidnap.Data;
using kidnap.DTO.Parents;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class ParentsService
    {
        public async Task<List<ParentsEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.parents.Include(x => x.mother).ThenInclude(x=>x.sex).
                Include(x => x.father).ThenInclude(x=>x.sex).
                ToListAsync();
            return list;
        }

        public async Task<ParentsEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.parents.Include(x => x.mother).ThenInclude(x => x.sex).
                Include(x => x.father).ThenInclude(x => x.sex).FirstOrDefaultAsync(x => x.id_parent == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<ParentsEntity> Create(CreateParentDTO createParent)
        {
            using var db = new DataContext();
            var item = new ParentsEntity()
            {
                id_mother = createParent.id_mother,
                id_father = createParent.id_father
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ParentsEntity> Update(UpdateParentDTO updateParent)
        {
            using var db = new DataContext();
            var item = new ParentsEntity()
            {
                id_parent = updateParent.id_parent,
                id_mother= updateParent.id_mother,
                id_father = updateParent.id_father
            };

            var result = db.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ParentsEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.parents.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
