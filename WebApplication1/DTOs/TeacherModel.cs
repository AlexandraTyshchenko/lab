using WebApplication1.entities;

namespace WebApplication1.DTOs
{
    public class TeacherModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortInfo { get; set; }
        public ICollection<string> Subjects { get; set; } = new List<string>();
    }
}
