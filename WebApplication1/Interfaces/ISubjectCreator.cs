namespace WebApplication1.Interfaces
{
    public interface ISubjectCreator
    {
        Task CreateSubject(string name, string description);
    }
}
