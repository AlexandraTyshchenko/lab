using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.entities;

namespace WebApplication1.EntityConfigurations
{
    public class ScheduleConfiguration: IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Day);
            builder.Property(s => s.NumberInOrder);
            builder.Property(s => s.Classroom);

            builder.HasOne(s => s.SubjectTeacher)
                .WithMany(y => y.Schedules)
                .HasForeignKey(s => s.SubjectTeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Group)
                .WithMany(y => y.Schedules)
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
