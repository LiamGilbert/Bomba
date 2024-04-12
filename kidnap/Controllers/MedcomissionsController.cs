using kidnap.DTO.Medcomissions;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/medcomissions")]
    public class MedcomissionsController : ControllerBase
    {
        private readonly MedcomissionsService medcomService = new MedcomissionsService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await medcomService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await medcomService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMedcomDTO createMedcom)
        {
            var item = await medcomService.Create(createMedcom);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateMedcomDTO updateMedcom)
        {
            var item = await medcomService.Update(updateMedcom);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await medcomService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
