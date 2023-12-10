using WebApplication1.entities;

namespace WebApplication1.Interfaces
{
    public interface ISubjectTeacherProvider
    {
        Task<IEnumerable<SubjectTeacher>> GetSubjectTeachersAsync();
    }
}
