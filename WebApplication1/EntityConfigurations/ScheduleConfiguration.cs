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

            builder.HasOne(s => s.Subject)
                .WithMany()
                .HasForeignKey(s => s.Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.Id)
                 .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.Group)
                .WithMany()
                .HasForeignKey(s => s.Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
