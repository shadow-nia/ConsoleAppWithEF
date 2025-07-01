using ConsoleAppWithEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var configurationBuilder = new ConfigurationBuilder();
configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
configurationBuilder.AddJsonFile("appsettings.json");
var config = configurationBuilder.Build();
var connectionString = config.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
var options = optionsBuilder.UseSqlite(connectionString).Options;


using (ApplicationContext db = new ApplicationContext(options))
{
    // Creating our objects
    User jacob = new User { Name = "Jacob", Age = 32 };
    // Adding our object to database 
    db.Users.Add(jacob);
    db.SaveChanges();
    Console.WriteLine("The object has been added successfully!");

}

using (ApplicationContext db = new ApplicationContext(options))
{
    // Getting our objects from database
    var users = db.Users.ToList();
    Console.WriteLine("List of objects:");
    foreach (var user in users) Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
}

using (ApplicationContext db = new ApplicationContext(options))
{
    // Updating last object from database
    User? user = db.Users.OrderBy(u => u.Id).LastOrDefault();
    if (user != null)
    {
        user.Name = "Thomas";
        user.Age = 28;
        //db.Users.Update(user);
        db.SaveChanges();
    }

    // Checking our new database
    var users = db.Users.ToList();
    Console.WriteLine("List of objects after updating:");
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");

}

using (ApplicationContext db = new ApplicationContext(options))
{
    // Deleting first object from database
    User? user = db.Users.OrderBy(u => u.Id).LastOrDefault();
    if (user != null)
    {
        db.Users.Remove(user);
        db.SaveChanges();
    }

    // Checking our new database
    var users = db.Users.ToList();
    Console.WriteLine("List of objects after deleting:");
    foreach (var u in users) Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");

}