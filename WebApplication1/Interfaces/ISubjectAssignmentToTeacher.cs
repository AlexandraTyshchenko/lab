namespace WebApplication1.Interfaces
{
    public interface ISubjectAssignmentToTeacher
    {
        Task AsignSubjectToTeacherAsync(int teacherId, int subjectId);
    }
}
