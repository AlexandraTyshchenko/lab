using WebApplication1.DTOs;
using WebApplication1.entities.enums;

namespace WebApplication1.Interfaces
{
    public interface IScheduleCreator
    {
        public Task CreateScheduleAsync(int number,int subjectTeacherId,string classroom,int groupId, Day day);
    }
}
