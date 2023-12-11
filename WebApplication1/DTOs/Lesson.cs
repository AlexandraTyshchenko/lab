using WebApplication1.entities.enums;
using WebApplication1.entities;

namespace WebApplication1.DTOs
{
    public class Lesson
    {
        public Day Day { get; set; }
        public int NumberInOrder { get; set; }
        public int GroupId { get; set; }
        public string Classroom { get; set; } = "";
        public string SubjectName { get; set; } = "";
        public string TeacherName { get; set; } = "";
    }
}
