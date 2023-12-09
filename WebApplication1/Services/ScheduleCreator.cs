using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.DTOs;
using WebApplication1.entities;
using WebApplication1.entities.enums;
using WebApplication1.Exceptions;
using WebApplication1.Interfaces;


namespace WebApplication1.Services
{
    public class ScheduleCreator : IScheduleCreator
    {
        private Context _dbContext;
        private readonly IMapper _mapper; 

        public ScheduleCreator(Context dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task CreateScheduleAsync(List<Lesson> lessons, Day DayOfWeek, int groupId)
        {
        //    var group = await _dbContext.Groups.FindAsync(groupId); 
        //    if(group == null) {
        //        throw new NotFoundException("group not found");
        //    }
        ////    var existingSchedules = _dbContext.Schedules
        ////.Where(s => s.Day == DayOfWeek && s.GroupId == groupId)
        ////.ToList(); todo
        //    var targetLessons = _mapper.Map<List<Schedule>>(lessons)
        //     .Select(schedule =>//додаємо параметри до кожної лекції дня тижня
        //       {
        //            schedule.Day = DayOfWeek;
        //            schedule.GroupId = groupId;
        //            schedule.Group = group;
        //          return schedule;
        //         }).ToList();

        //    await _dbContext.Schedules.AddRangeAsync(targetLessons);
          await _dbContext.SaveChangesAsync(); 
        }
    }
}
