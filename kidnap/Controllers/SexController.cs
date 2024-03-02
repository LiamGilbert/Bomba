using kidnap.Models;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/sexs")]
    public class SexController: ControllerBase
    {
        private readonly SexService service;
        public SexController()
        {
            this.service = new SexService();
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
            catch(Exception)
            {
                return NotFound();
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Create(SexEntity sex)
        {
            var item = await service.Create(sex);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(SexEntity sex)
        {
            var item = await service.Update(sex);
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
