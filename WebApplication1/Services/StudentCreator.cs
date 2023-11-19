using SendGrid.Helpers.Errors.Model;
using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class StudentCreator : IStudentCreator
    {
        private Context _context;

        public StudentCreator(Context context)
        {
            _context= context;
        }

        public async Task AddStudent(string firstName, string lastName, int groupId, string email)
        {
            var group = _context.Find<Group>(groupId);
            if (group == null)
            {
                throw new NotFoundException("group not found");
            }
            var student = new Student()
            {
                Name = firstName,
                LastName = lastName,
                GroupId = groupId,
                Group = group,
                Email = email
            };
            await _context.AddAsync(student);
            await _context.SaveChangesAsync();
        }
    }
}
