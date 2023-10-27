using Microsoft.EntityFrameworkCore;

using WebApplication1.entities;
using WebApplication1.EntityConfigurations;

namespace WebApplication1.dbContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
              : base(options)
        {
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new ScheduleConfiguration());
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
            modelBuilder.ApplyConfiguration(new TeacherConfiguration());
        }
    }
}
