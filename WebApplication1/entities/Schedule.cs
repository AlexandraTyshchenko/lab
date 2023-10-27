using System.Text.RegularExpressions;

namespace WebApplication1.entities
{
    public class Schedule : Base
    {
       public  enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday
        }
        public DayOfWeek Day { get; set; }
        public int? NumberInOrder { get; set; }
        public string Classroom { get; set; }
        public int? SubjectId { get; set; }
        public Subject? Subject { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
        public int? GroupId { get; set; }
        public Group? Group { get; set; }
    }

}
