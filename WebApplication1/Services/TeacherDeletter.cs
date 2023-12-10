using WebApplication1.dbContext;
using WebApplication1.Interfaces;
using WebApplication1.Exceptions;
namespace WebApplication1.Services
{
    public class TeacherDeletter : ITeacherDeletter
    {
        private Context _dbContext;

        public TeacherDeletter(Context dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task DeleteTeacherAsync(int teacherId)
        {
            var teacher = await _dbContext.Teachers.FindAsync(teacherId);
            if (teacher == null)
            {
                throw new NotFoundException("student not found");

            }
            _dbContext.Teachers.Remove(teacher);
            await _dbContext.SaveChangesAsync();
        }
    }
}
