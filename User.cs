using Microsoft.EntityFrameworkCore;

namespace ConsoleAppWithEF
{
    //[EntityTypeConfiguration(typeof(UserConfiguration))]
    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

    }
}
