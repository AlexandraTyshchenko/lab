using Microsoft.EntityFrameworkCore;
using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class SubjectsGetter : ISubjectsGetter
    {
        private Context _context;

        public SubjectsGetter(Context context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Subject>> GetSubjectsAsync()
        {
            var result = await _context.Subjects.ToListAsync();
            return result;
        }
    }
}
