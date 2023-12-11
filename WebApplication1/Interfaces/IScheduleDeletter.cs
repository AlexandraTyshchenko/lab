using WebApplication1.entities.enums;

namespace WebApplication1.Interfaces
{
    public interface IScheduleDeletter
    {
        Task DeleteSchedule(int numberInOrder,Day day,int GroupId);
    }
}
