using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.entities;

namespace WebApplication1.EntityConfigurations
{
    public class SubjectTeacherConfiguration : IEntityTypeConfiguration<SubjectTeacher>
    {

        public void Configure(EntityTypeBuilder<SubjectTeacher> builder)
        {
            builder.HasKey(s => s.Id);
                builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.HasOne(s => s.Subject)
               .WithMany(g => g.SubjectTeachers)
               .HasForeignKey(s => s.SubjectId)
               .OnDelete(DeleteBehavior.SetNull);
            builder.HasOne(s => s.Teacher)
             .WithMany(g => g.Subjects)
             .HasForeignKey(s => s.SubjectId)
             .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
