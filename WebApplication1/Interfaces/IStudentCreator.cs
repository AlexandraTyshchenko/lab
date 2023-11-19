using System.Text.RegularExpressions;
using WebApplication1.entities;

namespace WebApplication1.Interfaces
{
    public interface IStudentCreator
    { 
         public Task AddStudent(string firstName, string lastName ,int groupId,string email);
    }
}
