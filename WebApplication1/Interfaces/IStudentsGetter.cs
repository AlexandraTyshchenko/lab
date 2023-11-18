using WebApplication1.entities;

namespace WebApplication1.Interfaces
{
    public interface IStudentsGetter
    {
        int StudentsCount { get; }
        Task<ICollection<Student>> GetStudentsAsync(int groupId, int page, int pageSize);
    }
}
