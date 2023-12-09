using Microsoft.EntityFrameworkCore;
using System.Collections;

using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class GroupGetter : IGroupGetter
    {
        private Context _dbContext;

        public GroupGetter(Context dbcontext)
        {
            _dbContext= dbcontext;
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            var result = await _dbContext.Groups.ToListAsync();
            return result;
        }

    }
}
