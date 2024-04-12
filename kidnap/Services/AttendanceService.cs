using kidnap.Data;
using kidnap.DTO.Attendance;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class AttendanceService
    {
        public async Task<List<AttendanceEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.attendance.Include(x=>x.children).ThenInclude(x=>x.person).ThenInclude(x=>x.sex)
                .Include(x=>x.children).ThenInclude(x=>x.group)
                .Include(x=>x.reason)
                .ToListAsync();
            return list;
        }

        public async Task<AttendanceEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.attendance.Include(x => x.children).ThenInclude(x => x.person).ThenInclude(x => x.sex)
                .Include(x => x.children).ThenInclude(x => x.group)
                .Include(x => x.reason).FirstOrDefaultAsync(x => x.id_attendance == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<AttendanceEntity> Create(CreateAttendanceDTO createAttendance)
        {
            using var db = new DataContext();
            var item = new AttendanceEntity()
            {
                id_child = createAttendance.id_child,
                date = createAttendance.date,
                mark = createAttendance.mark,
                id_reason = createAttendance.id_reason
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AttendanceEntity> Update(UpdateAttendanceDTO updateAttendance)
        {
            using var db = new DataContext();
            var item = new AttendanceEntity()
            {
                id_attendance = updateAttendance.id_attendance,
                id_child = updateAttendance.id_child,
                date = updateAttendance.date,
                mark = updateAttendance.mark,
                id_reason = updateAttendance.id_reason
            };

            var result = db.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AttendanceEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.attendance.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
