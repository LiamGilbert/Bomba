using kidnap.Data;
using kidnap.DTO.Address;
using kidnap.Models;
using Microsoft.EntityFrameworkCore;

namespace kidnap.Services
{
    public class AddressService
    {
        public async Task<List<AddressEntity>> FindAll()
        {
            using var db = new DataContext();
            var list = await db.address.ToListAsync();
            return list;
        }

        public async Task<AddressEntity> FindById(int id)
        {
            using var db = new DataContext();
            var list = await db.address.FirstOrDefaultAsync(x => x.id_address == id);
            if (list == null)
            {
                throw new Exception();
            }
            return list;
        }

        public async Task<AddressEntity> Create(CreateAddressDTO createAddress)
        {
            using var db = new DataContext();
            var item = new AddressEntity()
            {
                town = createAddress.town,
                street = createAddress.street,
                house_number = createAddress.house_number
            };

            var result = await db.AddAsync(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AddressEntity> Update(UpdateAddressDTO updateAddress)
        {
            using var db = new DataContext();
            var item = new AddressEntity()
            {
                id_address = updateAddress.id_address,
                town = updateAddress.town,
                street = updateAddress.street,
                house_number = updateAddress.house_number
            };

            var result = db.Update(item);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<AddressEntity> Delete(int id)
        {
            using var db = new DataContext();
            var item = await FindById(id);
            var list = db.address.Remove(item);
            await db.SaveChangesAsync();
            return item;
        }
    }
}
