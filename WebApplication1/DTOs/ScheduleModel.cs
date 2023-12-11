using WebApplication1.entities.enums;

namespace WebApplication1.DTOs
{
    public class ScheduleModel
    {
        public int GroupId { get; set; }
        public List<Lesson> Monday { get; set; } = new List<Lesson>();
        public List<Lesson> Tuesday { get; set; } = new List<Lesson>();
        public List<Lesson> Wednesday { get; set; } = new List<Lesson>();
        public List<Lesson> Thursday { get; set; } = new List<Lesson>();
        public List<Lesson> Friday { get; set; } = new List<Lesson>();
    }

}
