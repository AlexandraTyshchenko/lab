
using WebApplication1.entities;

namespace WebApplication1.Interfaces
{
    public interface IGroupGetter
    {
        Task<IEnumerable<Group>> GetGroupsAsync();
    }
}
