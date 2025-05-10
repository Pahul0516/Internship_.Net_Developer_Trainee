using System;

public class User : Entity<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public User(string name, string email, string password) : base(-1)
    {
        Name = name;
        Email = email;
        Password = password;
    }
}
