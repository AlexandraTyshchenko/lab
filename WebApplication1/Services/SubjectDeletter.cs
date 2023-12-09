using WebApplication1.dbContext;
using WebApplication1.Interfaces;
using WebApplication1.Exceptions;
namespace WebApplication1.Services
{
    public class SubjectDeletter : ISubjectDeletter
    {
        private Context _dbContext;

        public SubjectDeletter(Context dbcontext)
        {
            _dbContext = dbcontext;
        }

        public async Task DeleteSubjectAsync(int SubjectId)
        {
            var subject = await _dbContext.Subjects.FindAsync(SubjectId);
            if (subject != null)
            {
                _dbContext.Subjects.Remove(subject);
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                throw new NotFoundException("student not found");
            }
        }
    }
}
