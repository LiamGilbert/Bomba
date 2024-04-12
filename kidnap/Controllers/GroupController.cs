using kidnap.DTO.Groups;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/groups")]
    public class GroupController: ControllerBase
    {
        private readonly GroupService groupService = new GroupService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await groupService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await groupService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateGroupDTO updateGroup)
        {
            var item = await groupService.Update(updateGroup);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await groupService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
