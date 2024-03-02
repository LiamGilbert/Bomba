using kidnap.DTO;
using kidnap.Models;
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

        [HttpPost]
        public async Task<IActionResult> Create(RoleEntity role)
        {
            var item = await service.Create(role);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoleEntity role)
        {
            var item = await service.Update(role);
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
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var item = await service.Login(dto);
                return Ok(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
