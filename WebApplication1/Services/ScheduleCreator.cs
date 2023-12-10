using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
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

        public ScheduleCreator(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateScheduleAsync(int number, int subjectTeacherId, string classroom, int groupId, Day day)
        {
            var group = await _dbContext.Groups.FindAsync(groupId);
            var subjectTeacher = await _dbContext.SubjectTeachers.FindAsync(subjectTeacherId);

            if(group == null) {
                throw new NotFoundException("group not found");
            }

            if(subjectTeacher == null)
            {
                throw new NotFoundException("subjectTeacher not found");
            }

            var existingSchedule = await _dbContext.Schedules.FirstOrDefaultAsync
                (x => x.Day == day && x.GroupId == groupId && x.NumberInOrder == number);

            if (existingSchedule != null)
            {
                existingSchedule.NumberInOrder = number;
                existingSchedule.Classroom = classroom;
                existingSchedule.SubjectTeacherId = subjectTeacherId;
                existingSchedule.SubjectTeacher = subjectTeacher;
                existingSchedule.GroupId = groupId;
                existingSchedule.Day = day;        
                existingSchedule.Group= group;       
            }
            else
            {
                var schedule = new Schedule
                {
                    NumberInOrder = number,
                    Classroom = classroom,
                    SubjectTeacherId = subjectTeacherId,
                    SubjectTeacher = subjectTeacher,
                    GroupId = groupId,
                    Group = group,
                    Day = day
                };
                _dbContext.Schedules.Add(schedule);
            }             
             await _dbContext.SaveChangesAsync(); 
        }
    }
}
