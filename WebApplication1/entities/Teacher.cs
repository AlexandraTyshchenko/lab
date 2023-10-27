using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.entities
{
    public class Teacher:Base
    {
        public string Name { get; set; }
        public string ShortInfo { get; set; }

        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
