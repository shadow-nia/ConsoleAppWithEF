using ConsoleAppWithEF;

using (ApplicationContext db = new ApplicationContext())
{
    // Creating our objects
    User jacob = new User { Name = "Jacob", Age = 32, Company = new Company { Name = "Google" } };
    // Adding our object to database 
    db.Users.Add(jacob);
    db.SaveChanges();
    Console.WriteLine("The object has been added successfully!");

}

using (ApplicationContext db = new ApplicationContext())
{
    // Getting our objects from database
    var users = db.Users.ToList();
    Console.WriteLine("List of objects:");
    foreach (var user in users) Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
}

using (ApplicationContext db = new ApplicationContext())
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

using (ApplicationContext db = new ApplicationContext())
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