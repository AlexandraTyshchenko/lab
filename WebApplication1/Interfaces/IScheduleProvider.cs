using WebApplication1.DTOs;

namespace WebApplication1.Interfaces
{
    public interface IScheduleProvider
    {
        Task<ScheduleModel> GetScheduleAsync(int groupId);
    }
}
