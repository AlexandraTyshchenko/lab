using WebApplication1.dbContext;
using WebApplication1.Interfaces;
using WebApplication1.Exceptions;

namespace WebApplication1.Services
{
    public class StudentDeletter : IStudentDeletter
    {
        private Context _context;

        public StudentDeletter(Context context)
        {
            _context = context;
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("student not found");
            }
        }
    }
}
