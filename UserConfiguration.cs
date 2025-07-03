using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEF
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("People").Property(p => p.Name).IsRequired();
            builder.ToTable(t => t.HasCheckConstraint("ValidAge", "Age > 17 AND Age < 120"));
            builder.Property(p => p.Id).HasColumnName("user_id");
            builder.Property(p => p.Age).HasDefaultValue(18);


        }
    }
}
