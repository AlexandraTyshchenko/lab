namespace WebApplication1.Interfaces
{
    public interface IScheduleCreator
    {
        public Task CreateScheduleAsync(string groupName);
    }
}
