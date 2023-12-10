using WebApplication1.entities.enums;
namespace WebApplication1.DTOs
{
    public class ScheduleParameters
    {
        public int number { get; set; }
        public int subjectTeacherId { get; set; }
        public string classroom { get; set; }
        public int groupId { get; set; }
        public Day day { get; set; }
    }
}
