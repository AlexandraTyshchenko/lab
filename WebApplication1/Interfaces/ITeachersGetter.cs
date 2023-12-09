using WebApplication1.entities;

namespace WebApplication1.Interfaces
{
    public interface ITeachersGetter
    {
        Task<IEnumerable<Teacher>> GetTeachersAsync();
    }
}
