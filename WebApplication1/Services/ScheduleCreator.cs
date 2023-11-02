using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class ScheduleCreator : IScheduleCreator
    {
        private Context _dbContext;

        public ScheduleCreator(Context dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task CreateScheduleAsync(string groupName)
        {
            var result = await _dbContext.Groups.Include(x => x.Schedules).FirstOrDefaultAsync(x => x.Name == groupName);
            if (result == null)
            {
                throw new NotFoundException("group not found");
            }
            if (result.Schedules.Count != 0)
            {
                throw new Exception("Schedule for the current group already exists");
            }


            var schedules = new List<Schedule>
        {
            new Schedule() { Day = Schedule.DayOfWeek.Monday,Group=result},
            new Schedule() { Day = Schedule.DayOfWeek.Tuesday,Group=result},
            new Schedule() { Day = Schedule.DayOfWeek.Wednesday,Group=result},
            new Schedule() { Day = Schedule.DayOfWeek.Thursday, Group = result },
            new Schedule() { Day = Schedule.DayOfWeek.Friday, Group = result},
        };

            await  _dbContext.Schedules.AddRangeAsync(schedules);
            await _dbContext.SaveChangesAsync();
        }
    }

}
