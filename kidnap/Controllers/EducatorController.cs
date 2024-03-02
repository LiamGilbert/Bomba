using kidnap.Models;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/educators")]
    public class EducatorController : ControllerBase
    {
        private readonly EducatorService service;
        public EducatorController()
        {
            this.service = new EducatorService();
        }

        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var list = await service.FindAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await service.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost]
        public async Task<IActionResult> Create(EducatorEntity educator)
        {
            var item = await service.Create(educator);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(EducatorEntity educator)
        {
            var item = await service.Update(educator);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await service.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
