using ConsoleAppWithEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    //public ApplicationContext()
    //{

    //    Database.EnsureCreated();
    //}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

        optionsBuilder.UseSqlite(config.GetConnectionString("DefaultConnection"));
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<User>().ToTable("People", schema: "userstore");
        modelBuilder.Entity<User>().Property("Id").HasField("id").HasColumnName("user_id");
        modelBuilder.Entity<User>().Property("Age").HasField("age");
        modelBuilder.Entity<User>().Property("name");
    }

}