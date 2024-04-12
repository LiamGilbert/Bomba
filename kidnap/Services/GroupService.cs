﻿using kidnap.Data;
using kidnap.DTO.Groups;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class GroupService
    {
        public async Task<List<GroupEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.groups.Include(x=>x.person).Include(x=>x.type).ToListAsync();
            return list;
        }

        public async Task<GroupEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.groups.Include(x => x.person).Include(x => x.type).
                FirstOrDefaultAsync(x => x.id_group == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<GroupEntity> Update(UpdateGroupDTO updateGroup)
        {
            using var db = new DataContext();
            var item = new GroupEntity()
            {
                id_group = updateGroup.id_group,
                group_name = updateGroup.group_name,
                id_educator = updateGroup.id_educator,
                id_grouptype = updateGroup.id_grouptype
            };

            var result = db.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<GroupEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.groups.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
