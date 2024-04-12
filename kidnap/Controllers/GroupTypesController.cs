using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/grouptypes")]
    public class GroupTypesController : ControllerBase
    {
        private readonly GroupTypesService service;
        public GroupTypesController()
        {
            this.service = new GroupTypesService();
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
    }
}
