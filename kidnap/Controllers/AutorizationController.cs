using kidnap.DTO.Autorization;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;
using Mysqlx;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/autorization")]
    public class AutorizationController: ControllerBase
    {
        private readonly AutorizationService autorizationService = new AutorizationService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await autorizationService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await autorizationService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAutorizationDTO createPerson)
        {
            var item = await autorizationService.Create(createPerson);
            return Ok(item);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var item = await autorizationService.Login(dto);
                return Ok(item);
            }
            catch(Exception)
            {
                return BadRequest();
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await autorizationService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
