using ConsoleAppWithEF;

using (ApplicationContext db = new ApplicationContext())
{
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();


    User bob = new User("Bob", 30);
    User kate = new User("Kate", 29);
    db.Users.Add(bob);
    db.Users.Add(kate);
    db.SaveChanges();

    var users = db.Users.ToList();
    foreach (User user in users)
    {
        user.Print();
    }
}