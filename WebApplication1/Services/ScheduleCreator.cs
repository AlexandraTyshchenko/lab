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
            var result = await _dbContext.Groups.FirstOrDefaultAsync(x => x.Name == groupName);
            //if (result == null)
            //{
            //    throw new NotFoundException("group not found");
            //}

            Schedule newSchedule = new Schedule
            {
                Day = Schedule.DayOfWeek.Monday,
                NumberInOrder = 1,
                Classroom = "A101",
                GroupId=result.Id
            };

       
          await  _dbContext.Schedules.AddAsync(newSchedule);
           await _dbContext.SaveChangesAsync();
        }
    }

}
