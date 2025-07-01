using ConsoleAppWithEF;

using (ApplicationContext db = new ApplicationContext())
{
    //// Create our objects
    //User alex = new User { Name = "Alex", Age = 24 };
    //User magda = new User { Name = "Magda", Age = 30 };

    //// Add our objects to database
    //db.Users.AddRange(alex, magda);
    //db.SaveChanges();
    //Console.WriteLine("The objects have been added successfully!");

    // Read out objects from database
    var users = db.Users.ToList();
    Console.WriteLine("List of objects:");
    foreach (var user in users) Console.WriteLine($"{user.Id}.{user.Name} - {user.Age}");
   
}


