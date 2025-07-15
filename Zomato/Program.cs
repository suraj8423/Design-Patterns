using System;
using Zomato.Models;

namespace Zomato;

public class Program
{
    public static void Main(string[] args)
    {
        // Create a new restaurant
        Restaurant restaurant = new Restaurant(1, "Pasta Palace", "Downtown", 4.5);
        
        // Add menu items to the restaurant
        restaurant.MenuItems = new List<MenuItem>
        {
            new MenuItem(1, "Spaghetti Carbonara", 12.99, "Classic Italian pasta with creamy sauce"),
            new MenuItem(2, "Margherita Pizza", 10.99, "Traditional pizza with fresh basil and mozzarella"),
            new MenuItem(3, "Tiramisu", 6.99, "Delicious coffee-flavored dessert")
        };
        
        // Display restaurant details
        Console.WriteLine($"Restaurant: {restaurant.Name}, Location: {restaurant.Location}, Rating: {restaurant.Rating}");
        
        // Display menu items
        foreach (var item in restaurant.MenuItems)
        {
            Console.WriteLine($"Menu Item: {item.Name}, Price: {item.Price}, Description: {item.Description}");
        }
    }
}
