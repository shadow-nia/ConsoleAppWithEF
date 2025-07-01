using ConsoleAppWithEF;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  {
        Database.EnsureCreated(); 
    }
}