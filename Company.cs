using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEF
{
    //[EntityTypeConfiguration(typeof(CompanyConfiguration))]
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<User> Users { get; set; } = new();
    }
}
