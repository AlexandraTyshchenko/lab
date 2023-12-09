using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class TeacherGetter : ITeachersGetter
    {
        private Context _dbContext;

        public TeacherGetter(Context dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            var result = await _dbContext.Teachers.ToListAsync();
            return result;
        }
    }
}
