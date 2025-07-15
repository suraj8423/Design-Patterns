# Single Responsibility Principle

- If you making change in your class then there should be one and only one reason should be there.
- So the main problem with not following srp is that after each change you have to test functionality because you have not followed the single responsbility principle.


### Example without following SRP
```csharp
using System;
using System.Collections.Generic;

namespace SRPDemo
{
    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        private List<string> Transactions = new List<string>();

        public BankAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited ${amount}. New Balance: ${Balance}");
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            Transactions.Add($"Withdrew ${amount}. New Balance: ${Balance}");
        }

        public void PrintStatement()
        {
            Console.WriteLine($"Statement for Account: {AccountNumber}");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
```

### Example with following SRP

```csharp
using System;
using System.Collections.Generic;

namespace SRPDemo
{
    public class BankAccount
    {
        public int AccountNumber { get; private set; }
        public double Balance { get; private set; }
        public List<string> Transactions = new List<string>();

        public BankAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
            Transactions.Add($"Deposited ${amount}. New Balance: ${Balance}");
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            Transactions.Add($"Withdrew ${amount}. New Balance: ${Balance}");
        }
    }

    public class StatementPrinter
    {
        public void Print(BankAccount account)
        {
            Console.WriteLine($"Statement for Account: {account.AccountNumber}");
            foreach (var transaction in account.Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
    
    //Testing the Single Responsibility Principle
    public class Program
    {
        public static void Main()
        {
            BankAccount johnsAccount = new BankAccount(123456);
            johnsAccount.Deposit(500);
            johnsAccount.Withdraw(100);

            StatementPrinter printer = new StatementPrinter();
            printer.Print(johnsAccount);
            
            Console.ReadKey();
        }
    }
}
```