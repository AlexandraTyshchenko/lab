using WebApplication1.DTOs;
using WebApplication1.entities.enums;

namespace WebApplication1.Interfaces
{
    public interface IScheduleCreator
    {

        public Task CreateScheduleAsync(List<Lesson> lessons, Day Day, int groupId);
    }
}
