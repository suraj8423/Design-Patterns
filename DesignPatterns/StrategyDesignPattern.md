# When to use Strategy design pattern

- When we have multiple ways to perform an operation and we want to switch them dynamically.
- If we want to avoid large if-else condition or we do not want to voilate the DRY(don't repeat yourself) principle (Duck example).
- You want to seperate the code that can change from the code that stays the same.

```csharp
public class PaymentService {
    public void Pay(string paymentType, double amount) {
        if (paymentType == "CreditCard") {
            Console.WriteLine("Processing credit card payment of " + amount);
            // Credit card logic
        } else if (paymentType == "PayPal") {
            Console.WriteLine("Processing PayPal payment of " + amount);
            // PayPal logic
        } else if (paymentType == "UPI") {
            Console.WriteLine("Processing UPI payment of " + amount);
            // UPI logic
        }
    }
}

- So here if you see whenevera new payment system will come we have to open this class again and add one more entry.
- This action will break open-close principle also.
- So solution is strategy principle as Our Goal is payment but we have different strategy for the same. 
```

```csharp
using System;
using System.Runtime.CompilerServices;

namespace StrategyPatternExample;

public interface IPaymentGateway
{
    void ProcessPayment(decimal amount);
}

public class PaypalPaymentGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} through PayPal.");
    }
}

public class StripePaymentGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} through Stripe.");
    }
}

public class CreditCardPaymentGateway : IPaymentGateway
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} through Credit Card.");
    }
}

public class PaymentProcessor
{
    private readonly IPaymentGateway _paymentGateway;

    public PaymentProcessor(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public void MakePayment(decimal amount)
    {
        _paymentGateway.ProcessPayment(amount);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var processor = new PaymentProcessor(new PaypalPaymentGateway());
        processor.MakePayment(100.00m);
    }
}
```