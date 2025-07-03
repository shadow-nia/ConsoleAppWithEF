using ConsoleAppWithEF;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();


    User bob = new User { Name = "Bob", Age = 30 };
    User kate = new User{ Name = "Kate", Age = 29 };
    db.Users.Add(bob);
    db.Users.Add(kate);
    db.SaveChanges();

    var users = db.Users.ToList();
    foreach (User user in users)
    {
        Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
    }
}