using WebApplication1.dbContext;
using WebApplication1.entities;
using WebApplication1.Interfaces;

namespace WebApplication1.Services
{
    public class GroupCreator : IGroupCreator
    {
        private Context _dbcontext;

        public GroupCreator(Context dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task CreateGroup(string groupName, int groupCourse, string groupCurator)
        {
            var group = new Group() { Name=groupName, Course=groupCourse, Curator=groupCurator};
            await  _dbcontext.Groups.AddAsync(group);
            _dbcontext.SaveChanges();
        }
    }
}
