using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/roles")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService service;
        public RoleController()
        {
            this.service = new RoleService();
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
