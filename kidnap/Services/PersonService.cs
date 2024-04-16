using kidnap.Data;
using kidnap.DTO.Persons;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class PersonService
    {
        public async Task<List<PersonEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.persons.Include(x=>x.address).Include(x=>x.role).ToListAsync();
            return list;
        }

        public async Task<PersonEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.persons.Include(x => x.address).Include(x => x.role).
                FirstOrDefaultAsync(x => x.id_person == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<PersonEntity> Create(CreatePersonDTO createPerson)
        {
            using var db = new DataContext();
            var item = new PersonEntity()
            {
                lastname = createPerson.lastname,
                firstname = createPerson.firstname,
                patronymic = createPerson.patronymic,
                sex = createPerson.sex,
                id_address = createPerson.id_address,
                id_role = createPerson.id_role
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PersonEntity> Update(UpdatePersonDTO updatePerson)
        {
            using var db = new DataContext();
            var item = new PersonEntity()
            {
                id_person = updatePerson.id_person,
                lastname = updatePerson.lastname,
                firstname = updatePerson.firstname,
                patronymic = updatePerson.patronymic,
                sex = updatePerson.sex,
                id_address = updatePerson.id_address,
                id_role = updatePerson.id_role
            };

            var result = db.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<PersonEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.persons.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
