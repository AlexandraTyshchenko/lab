namespace WebApplication1.entities
{
    public class Group:Base
    {
        public string Name { get; set; } 
        public int? Course { get; set; }
        public string Curator { get; set; } 

        public ICollection<Student> Students { get; set; }=new List<Student>();
        public ICollection<Schedule> Schedules { get; set; }=new List<Schedule>();
    }
}
