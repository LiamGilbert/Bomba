using kidnap.DTO.Childrens;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/childrens")]
    public class ChildrensController: ControllerBase
    {
        private readonly ChildrensService childService = new ChildrensService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await childService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await childService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateChildDTO createChild)
        {
            var item = await childService.Create(createChild);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateChildDTO updateChild)
        {
            var item = await childService.Update(updateChild);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await childService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
