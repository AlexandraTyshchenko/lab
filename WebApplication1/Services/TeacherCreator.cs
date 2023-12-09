using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class TeacherCreator:ITeacherCreator
    {
        private Context _dbContext;

        public TeacherCreator(Context dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task AddTeacher(string teacherName, string shortInfo)
        {
            var teacher = new Teacher { Name = teacherName,ShortInfo = shortInfo };
            await _dbContext.Teachers.AddAsync(teacher);
            await _dbContext.SaveChangesAsync();
        }
    }
}
