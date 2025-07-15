using System;

namespace DecoratorPatternExample;

public interface Pizza
{
    string MakePizza();
}

public class PlainPizza : Pizza
{
    public string MakePizza()
    {
        return "Plain Pizza";
    }
}

// now agr future me different types of pizza aane lage jaise pizza with cheese, pizza with olives, etc.
// then if we will extent the Pizza interface then we have to create so many new classes and that will be a problem right.
// So to solve this problem we will use Decorator Pattern.

public abstract class PizzaDecorator : Pizza
{
    // first create a protected field of type Pizza to store the existing pizza object
    protected Pizza _pizza;

    public PizzaDecorator(Pizza pizza)
    {
        _pizza = pizza;
    }

    public virtual string MakePizza()
    {
        return _pizza.MakePizza();
    }
}

public class ChickenPizzaDecorator : PizzaDecorator
{
    public ChickenPizzaDecorator(Pizza pizza) : base(pizza) { }

    public override string MakePizza()
    {
        return _pizza.MakePizza() + ", Chicken Pizza";
    }
}

public class CheesePizzaDecorator : PizzaDecorator
{
    public CheesePizzaDecorator(Pizza pizza) : base(pizza) { }

    public override string MakePizza()
    {
        return _pizza.MakePizza() + ", Cheese Pizza";
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        // create a plain pizza
        Pizza pizza = new PlainPizza();
        Console.WriteLine(pizza.MakePizza());

        // now add chicken to the pizza
        pizza = new ChickenPizzaDecorator(pizza);
        Console.WriteLine(pizza.MakePizza());

        // now add cheese to the pizza
        pizza = new CheesePizzaDecorator(pizza);
        Console.WriteLine(pizza.MakePizza());
    }
}