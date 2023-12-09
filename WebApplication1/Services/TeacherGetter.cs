using Microsoft.EntityFrameworkCore;
using WebApplication1.Exceptions;
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

        public async Task<Teacher> GetTeacherByID(int id)
        {
           var result = await _dbContext.Teachers.Include(x => x.Subjects).ThenInclude(x => x.Subject).FirstOrDefaultAsync(x=>x.Id == id);
            if(result == null)
            {
                throw new NotFoundException("teacher is not found");
            }
            return result;
        }

        public async Task<IEnumerable<Teacher>> GetTeachersAsync()
        {
            var result = await _dbContext.Teachers.Include(x=>x.Subjects).ThenInclude(x=>x.Subject).ToListAsync();
            return result;
        }
    }
}
