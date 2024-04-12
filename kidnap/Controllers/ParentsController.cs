using kidnap.DTO.Parents;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/parents")]
    public class ParentsController : ControllerBase
    {
        private readonly ParentsService parentsService = new ParentsService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await parentsService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await parentsService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateParentDTO createParent)
        {
            var item = await parentsService.Create(createParent);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateParentDTO updateParent)
        {
            var item = await parentsService.Update(updateParent);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await parentsService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
