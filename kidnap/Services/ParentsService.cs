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
            var list = await db.parents.Include(x => x.mother).Include(x=>x.father).
                ToListAsync();
            return list;
        }

        public async Task<ParentsEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.parents.Include(x => x.mother).
                Include(x => x.father).FirstOrDefaultAsync(x => x.id_parent == id);
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
                mother = createParent.mother,
                father = createParent.father,
                id_children = createParent.id_children
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
                mother = updateParent.mother,
                father = updateParent.father,
                id_children = updateParent.id_children
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
