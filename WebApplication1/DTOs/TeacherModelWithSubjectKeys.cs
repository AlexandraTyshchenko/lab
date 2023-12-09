using WebApplication1.entities;

namespace WebApplication1.DTOs
{
    public class TeacherModelWithSubjectKeys
    {
        public int Id { get; set; }
        public ICollection<SubjectModel> Subjects{ get; set; } = new List<SubjectModel>();
    }
}
