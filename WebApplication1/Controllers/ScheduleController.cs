using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> CreateSchedule(string groupName)
        {
             await _scheduleCreator.CreateScheduleAsync(groupName);
             return Ok();

        }
    }
}
