using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication1.Services
{
    public class StudentsGetter : IStudentsGetter
    {
        private Context _dbContext;

        public StudentsGetter(Context dbContext)
        {
            _dbContext= dbContext;
            StudentsCount = _dbContext.Students.Count();
        }

        public int StudentsCount { get;}

        public async Task<ICollection<Student>> GetStudentsAsync(int groupId, int page, int pageSize)
        {
            int startIndex = (page - 1) * pageSize;

            var result = await _dbContext.Students
                .Where(x => x.GroupId == groupId)
                .Skip(startIndex)
                .Take(pageSize)
                .ToListAsync(); 
            return result;
        }
    }
}
