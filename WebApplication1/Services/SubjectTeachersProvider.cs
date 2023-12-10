using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class SubjectTeachersProvider : ISubjectTeacherProvider
    {
        private Context _context;

        public SubjectTeachersProvider(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SubjectTeacher>> GetSubjectTeachersAsync()
        {
            var result = await _context.SubjectTeachers.Include(x=>x.Teacher).Include(x=>x.Subject).ToListAsync();
            return result;
        }
    }
}
