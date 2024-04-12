using kidnap.DTO.Attendance;
using kidnap.Services;
using Microsoft.AspNetCore.Mvc;

namespace kidnap.Controllers
{
    [ApiController]
    [Route("v1/attendance")]
    public class AttendanceController: ControllerBase
    {
        private readonly AttendanceService attendanceService = new AttendanceService();
        [HttpGet]
        public async Task<IActionResult> FindAll()
        {
            var items = await attendanceService.FindAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(int id)
        {
            try
            {
                var item = await attendanceService.FindById(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAttendanceDTO createAttendance)
        {
            var item = await attendanceService.Create(createAttendance);
            return Ok(item);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateAttendanceDTO updateAttendance)
        {
            var item = await attendanceService.Update(updateAttendance);
            return Ok(item);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await attendanceService.Delete(id);
                return Ok(item);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
