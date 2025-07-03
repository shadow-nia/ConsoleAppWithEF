using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEF
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder
                .HasOne(u => u.Company)
                .WithMany(c => c.Users);
                //.HasForeignKey(u => u.CompanyId);


        }
    }
}
