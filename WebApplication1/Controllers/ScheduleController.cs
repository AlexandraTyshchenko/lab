using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.entities.enums;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private IScheduleCreator _scheduleCreator;

        public ScheduleController(IScheduleCreator scheduleCreator)
        {
            _scheduleCreator = scheduleCreator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule(List<Lesson> lessons, [FromQuery] Day Day, [FromQuery] int groupId)
        {
            await _scheduleCreator.CreateScheduleAsync(lessons, Day, groupId);
            return Ok();
        }

    }
}
