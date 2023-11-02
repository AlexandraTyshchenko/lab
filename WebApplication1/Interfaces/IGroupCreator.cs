namespace WebApplication1.Interfaces
{
    public interface IGroupCreator
    {
        public Task CreateGroup(string groupName,int groupCourse, string groupCurator);
    }
}
