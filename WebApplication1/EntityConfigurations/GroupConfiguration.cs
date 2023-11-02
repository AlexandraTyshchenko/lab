using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.entities;

namespace WebApplication1.EntityConfigurations
{
    public class GroupConfiguration: IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(g => g.Name);
            builder.Property(g => g.Course);
            builder.Property(g => g.Curator);

        }
    }
}
