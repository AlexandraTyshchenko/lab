namespace WebApplication1.entities
{
    public class SubjectTeacher:Base
    {
        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set;}
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();

    }
}
