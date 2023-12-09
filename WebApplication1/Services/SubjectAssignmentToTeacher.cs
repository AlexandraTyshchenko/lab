using WebApplication1.dbContext;
using WebApplication1.Interfaces;
using WebApplication1.Exceptions;
using WebApplication1.entities;

namespace WebApplication1.Services
{
    public class SubjectAssignmentToTeacher : ISubjectAssignmentToTeacher
    {
        private Context _dbContext;

        public SubjectAssignmentToTeacher(Context dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task AsignSubjectToTeacherAsync(int teacherId, int subjectId)
        {
            var teacher = await _dbContext.Teachers.FindAsync(teacherId);
            var subject = await _dbContext.Subjects.FindAsync(subjectId);

            if (teacher == null)
            {
                throw new NotFoundException("teacher not found");
            }

            if (subject == null)
            {
                throw new NotFoundException("subject not found");
            }

            var SubjectTeacher = new SubjectTeacher
            {
                TeacherId = teacherId,
                SubjectId = subjectId,
                Teacher = teacher,
                Subject = subject
            };
            await _dbContext.SubjectTeachers.AddAsync(SubjectTeacher);
            await _dbContext.SaveChangesAsync();
        }
    }
}
