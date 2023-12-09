using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class SubjectCreator : ISubjectCreator
    {
        private Context _context;

        public SubjectCreator(Context context)
        {
            _context = context;
        }

        public async Task CreateSubject(string name, string description)
        {
           var subject = new Subject { Name = name, Description = description };
           await _context.Subjects.AddAsync(subject); 
           await _context.SaveChangesAsync();
        }
    }
}
