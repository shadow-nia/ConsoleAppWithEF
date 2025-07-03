using ConsoleAppWithEF;

using (ApplicationContext db = new ApplicationContext())
{
    Company company1 = new Company { Name = "Google" };
    Company company2 = new Company { Name = "Microsoft" };
    User user1 = new User { Name = "Tom", Company = company1 };
    User user2 = new User { Name = "Bob", Company = company2 };
    User user3 = new User { Name = "Sam", Company = company2 };

    db.Companies.AddRange(company1, company2);
    db.Users.AddRange(user1, user2, user3);
    db.SaveChanges();

    foreach (var user in db.Users.ToList())
    {
        Console.WriteLine($"{user.Name} works in {user.Company?.Name}");
    }
}