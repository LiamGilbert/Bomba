using kidnap.Data;
using kidnap.DTO.Persons;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mysqlx;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/people")]
    public class PersonController: ControllerBase
    {
        private readonly PersonService personService = new PersonService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await personService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await personService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePersonDTO createPerson)
        {
            var item = await personService.Create(createPerson);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePersonDTO updatePerson)
        {
            var item = await personService.Update(updatePerson);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await personService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
