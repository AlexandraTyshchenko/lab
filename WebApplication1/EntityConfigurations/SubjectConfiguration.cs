using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WebApplication1.entities;

namespace WebApplication1.EntityConfigurations
{
    public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Name);
            builder.Property(s => s.Description);

            
            builder.HasOne(s => s.Teacher)
                .WithMany()
                .HasForeignKey(s => s.TeacherId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
