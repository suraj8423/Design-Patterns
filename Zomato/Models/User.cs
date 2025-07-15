using System;

namespace Zomato.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public Cart Cart { get; set; }

    public User(int id, string name, string email, string password)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
    }
}