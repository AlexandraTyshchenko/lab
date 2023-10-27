using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.entities
{
    public class Subject : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TeacherId { get; set; }
        public Teacher? Teacher { get; set; }
    }
}
