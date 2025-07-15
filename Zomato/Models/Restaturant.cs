using System;
using System.Collections.Generic;
namespace Zomato.Models;

public class Restaurant
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
    public double Rating { get; set; }
    public List<MenuItem> MenuItems { get; set; }

    public Restaurant(int id, string name, string location, double rating)
    {
        Id = id;
        Name = name;
        Location = location;
        Rating = rating;
    }
}