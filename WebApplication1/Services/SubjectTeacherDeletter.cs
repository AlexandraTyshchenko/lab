using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.Interfaces;
using WebApplication1.Exceptions;

namespace WebApplication1.Services
{
    public class SubjectTeacherDeletter : ISubjectTeacherDeletter
    {
        private Context _dbContext;

        public SubjectTeacherDeletter(Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task DeleteSubjectAsync(int teacherId, int subjectId)
        {
            var subjectTeacher = await _dbContext.SubjectTeachers
                .FirstOrDefaultAsync(x => x.TeacherId == teacherId && x.SubjectId == subjectId);

            if (subjectTeacher != null)
            {
                _dbContext.SubjectTeachers.Remove(subjectTeacher);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("Subjects are not found");
            }
        }
    }
}
