using WebApplication1.entities;

namespace WebApplication1.Interfaces
{
    public interface ISubjectsGetter
    {
        Task<IEnumerable<Subject>> GetSubjectsAsync();
    }
}
