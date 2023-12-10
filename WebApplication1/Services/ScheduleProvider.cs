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
           var list =await _context.Schedules.Where(x => x.GroupId == groupId).
                Include(x => x.SubjectTeacher).ThenInclude(x => x.Subject).Include(x => x.SubjectTeacher)
                .ThenInclude(x => x.Teacher).ToListAsync();
            var mappedResult = _mapper.Map<List<Lesson>>(list);
            var schedulemodel = new ScheduleModel();
            schedulemodel.GroupId = groupId;
            schedulemodel.Monday = mappedResult.Where(x=>x.Day == Day.Monday).
                OrderBy(x=>x.NumberInOrder).ToList();
            schedulemodel.Tuesday = mappedResult.Where(x => x.Day == Day.Tuesday).
                OrderBy(x => x.NumberInOrder).ToList();
            schedulemodel.Wednesday = mappedResult.Where(x => x.Day == Day.Wednesday).
                OrderBy(x => x.NumberInOrder).ToList();
            schedulemodel.Thursday = mappedResult.Where(x => x.Day == Day.Thursday)
                .OrderBy(x => x.NumberInOrder).ToList();
            schedulemodel.Friday = mappedResult.Where(x => x.Day == Day.Friday).
                OrderBy(x => x.NumberInOrder).ToList(); 
            return schedulemodel;
        }

    }
}
