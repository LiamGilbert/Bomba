using kidnap.DTO.Address;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/address")]

    public class AddressController: ControllerBase
    {
        private readonly AddressService addressService = new AddressService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await addressService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await addressService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAddressDTO createAddress)
        {
            var item = await addressService.Create(createAddress);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAddressDTO updateAddress)
        {
            var item = await addressService.Update(updateAddress);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await addressService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
