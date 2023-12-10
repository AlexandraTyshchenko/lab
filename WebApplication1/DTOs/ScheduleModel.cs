using WebApplication1.entities.enums;

namespace WebApplication1.DTOs
{
    public class ScheduleModel
    {
        public int GroupId { get; set; }
        public IEnumerable<Lesson> Monday { get; set; }
        public IEnumerable<Lesson> Tuesday { get; set; }
        public IEnumerable<Lesson> Wednesday { get; set; }
        public IEnumerable<Lesson> Thursday { get; set; }
        public IEnumerable<Lesson> Friday { get; set; }
    }
}
