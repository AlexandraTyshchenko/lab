using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.DTOs;
using WebApplication1.entities.enums;
using WebApplication1.Interfaces;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleCreator _scheduleCreator;
        private readonly IScheduleProvider _scheduleProvider;
        private readonly Context _context;

        public ScheduleController(IScheduleCreator scheduleCreator,Context context, IScheduleProvider scheduleProvider)
        {
            _scheduleCreator = scheduleCreator;
            _context = context;
            _scheduleProvider = scheduleProvider;
        }

        [HttpPut]
        public async Task<IActionResult> CreateSchedule([FromQuery] ScheduleParameters scheduleParameters)
        {
            await _scheduleCreator.CreateScheduleAsync(scheduleParameters.number,
                scheduleParameters.subjectTeacherId, scheduleParameters.classroom,
                scheduleParameters.groupId, scheduleParameters.day
                );
            return Ok();
        }

        [HttpGet("test")]
        public async Task<IActionResult> GetTest()
        {
            var result = await _context.Schedules.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedule(int groupId)
        {
            var result =await  _scheduleProvider.GetScheduleAsync(groupId);
            return Ok(result);
        }

    }
}
