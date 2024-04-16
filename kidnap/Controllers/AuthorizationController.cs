using kidnap.Services;
using Microsoft.AspNetCore.Mvc;
using kidnap.DTO.Autorization;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/authorization")]
    public class AuthorizationController: ControllerBase
    {
        private readonly AuthorizationService authorizationService = new AuthorizationService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await authorizationService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await authorizationService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAuthorizationDTO createPerson)
        {
            var item = await authorizationService.Create(createPerson);
            return Ok(item);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            try
            {
                var item = await authorizationService.Login(dto);
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
                var item = await authorizationService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
