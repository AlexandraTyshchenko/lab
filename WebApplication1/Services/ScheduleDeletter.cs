using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.entities.enums;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class ScheduleDeletter : IScheduleDeletter
    {
        private readonly Context _dbContext;

        public ScheduleDeletter(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteSchedule(int numberInOrder, Day day, int GroupId)
        {
            var result = await _dbContext.Schedules.FirstOrDefaultAsync(x => x.NumberInOrder == numberInOrder
            && x.Day == day && x.GroupId == GroupId
            );
            if( result == null ) {
                throw new NotFoundException();
            }
            _dbContext.Schedules.Remove( result );
            await _dbContext.SaveChangesAsync();
        }
    }
}
