using WebApplication1.dbContext;
using WebApplication1.DTOs;
using WebApplication1.Interfaces;

using Microsoft.EntityFrameworkCore;
using AutoMapper;
using WebApplication1.entities;
using WebApplication1.entities.enums;

namespace WebApplication1.Services
{
    public class ScheduleProvider : IScheduleProvider
    {
        private Context _context;
        private IMapper _mapper;

        public ScheduleProvider(Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ScheduleModel> GetScheduleAsync(int groupId)
        {

            var list = await _context.Schedules.Where(x => x.GroupId == groupId)
                .Include(x => x.SubjectTeacher).ThenInclude(x => x.Subject).Include(x => x.SubjectTeacher)
                .ThenInclude(x => x.Teacher).ToListAsync();

            var mappedResult = _mapper.Map<List<Lesson>>(list);
            var schedulemodel = new ScheduleModel();
            schedulemodel.GroupId = groupId;

            FillDay(schedulemodel.Monday, mappedResult.Where(x => x.Day == Day.Monday).ToList(),  groupId,Day.Monday);
            FillDay(schedulemodel.Tuesday, mappedResult.Where(x => x.Day == Day.Tuesday).ToList(), groupId, Day.Tuesday);
            FillDay(schedulemodel.Wednesday, mappedResult.Where(x => x.Day == Day.Wednesday).ToList(), groupId, Day.Wednesday);
            FillDay(schedulemodel.Thursday, mappedResult.Where(x => x.Day == Day.Thursday).ToList(), groupId, Day.Thursday);
            FillDay(schedulemodel.Friday, mappedResult.Where(x => x.Day == Day.Friday).ToList(), groupId,Day.Friday);
            return schedulemodel;
        }

        private void FillDay(List<Lesson> dayLessons, IEnumerable<Lesson> lessons, int groupId, Day day)
        {
            for (int i = 1; i <= 8; i++)
            {
                Lesson defaultLesson = new Lesson
                {
                    GroupId = groupId
                };

                Lesson lesson = lessons.FirstOrDefault(x => x.NumberInOrder == i);
                if (lesson == null)
                {
                    defaultLesson.NumberInOrder = i;
                    defaultLesson.Day = day;
                    lesson = defaultLesson;
                }
                dayLessons.Add(lesson);
            }

            dayLessons.Sort((x, y) => x.NumberInOrder.CompareTo(y.NumberInOrder));
        }


    }
}
