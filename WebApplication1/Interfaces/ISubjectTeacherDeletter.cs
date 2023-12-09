namespace WebApplication1.Interfaces
{
    public interface ISubjectTeacherDeletter
    {
        Task DeleteSubjectAsync(int teacherId, int subjectId);
    }
}
