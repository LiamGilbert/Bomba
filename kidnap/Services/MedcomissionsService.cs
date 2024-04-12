using kidnap.Data;
using kidnap.DTO.Medcomissions;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class MedcomissionsService
    {
        public async Task<List<MedcomissionsEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.medcomissions.Include(x => x.medstatus).ToListAsync();
            return list;
        }

        public async Task<MedcomissionsEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.medcomissions.Include(x => x.medstatus).
                FirstOrDefaultAsync(x => x.id_medcomission == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<MedcomissionsEntity> Create(CreateMedcomDTO createMedcom)
        {
            using var db = new DataContext();
            var item = new MedcomissionsEntity()
            {
                id_medstatus = createMedcom.id_medstatus,
                date = createMedcom.date
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<MedcomissionsEntity> Update(UpdateMedcomDTO updateMedcom)
        {
            using var db = new DataContext();
            var item = new MedcomissionsEntity()
            {
                id_medcomission = updateMedcom.id_medcomission,
                id_medstatus = updateMedcom.id_medstatus,
                date = updateMedcom.date
            };

            var result = db.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<MedcomissionsEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.medcomissions.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
