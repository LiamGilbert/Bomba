using kidnap.Data;
using kidnap.DTO.Childrens;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class ChildrensService
    {
        public async Task<List<ChildrensEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.childrens
                .Include(x => x.group)
                .Include(x => x.person).ThenInclude(x=>x.address)
                .Include(x => x.parents).ThenInclude(x=>x.father)
                .Include(x => x.medcomission).ThenInclude(x=>x.medstatus)
                .ToListAsync();
            return list;
        }

        public async Task<ChildrensEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.childrens.Include(x => x.group)
                .Include(x => x.person)
                .Include(x => x.parents).ThenInclude(x => x.father)
                .Include(x => x.medcomission)
                .FirstOrDefaultAsync(x => x.id_children == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<ChildrensEntity> Create(CreateChildDTO createChild)
        {
            using var db = new DataContext();
            var item = new ChildrensEntity()
            {
                id_person = createChild.id_person,
                id_group = createChild.id_group,
                id_parent = createChild.id_parent,
                id_medcomission = createChild.id_medcomission
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ChildrensEntity> Update(UpdateChildDTO updateChild)
        {
            using var db = new DataContext();
            var item = new ChildrensEntity()
            {
                id_children = updateChild.id_children,
                id_person = updateChild.id_person,
                id_group = updateChild.id_group,
                id_parent = updateChild.id_parent,
                id_medcomission = updateChild.id_medcomission
            };

            var result = db.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ChildrensEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.childrens.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
