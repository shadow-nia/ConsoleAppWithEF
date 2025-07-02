using ConsoleAppWithEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users => Set<User>();
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)  {
        Database.EnsureCreated(); 
    }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    var config = new ConfigurationBuilder()
    //                    .AddJsonFile("appsettings.json")
    //                    .SetBasePath(Directory.GetCurrentDirectory())
    //                    .Build();

    //    optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
    //}
}