# Factory Design Pattern

- helps in object creating but different objects can create depending on different use cases.

- In almost all the design patterns our goal is very clear we want to seperate the business logic and object creation logic.

- Use this factory design pattern if you want to seperate the object creation logic from the business logic.

- But the main question is we can do the same thing with strategy design pattern also then why to use factory design pattern. If we will use factory design pattern it will break open-close principle also still we use this so the answer is very simple and it is very subjective also... when you stuck on this confusion then think if object creation is already handled or not if you find that object creation is not handled properly for your case then better go with Factory else use strategy design pattern only.

###  1. Why not just use Strategy everywhere?
- 👉 Strategy pattern is mainly about selecting behavior (algorithms) at runtime.

- Example: You already have all behaviors (strategies) created (like different sorting or payment algorithms).

- You just plug in the one you want.

- The key point is: strategies are usually provided by the client (you pass it to the context).

- ➡️ The Strategy pattern does NOT concern itself with creating objects. It’s more about how to execute different logic using existing implementations.

### 2. Then what does Factory do that Strategy doesn't?
- 👉 The Factory pattern is purely about creation.

- It hides or encapsulates object instantiation logic.

- It decides which concrete class to instantiate and returns an object.

- Your client code doesn’t even know which concrete class exists.
It only knows the interface or base class.

### 3. About Open/Closed Principle (OCP)
- You’re absolutely right:

- 👉 In a basic switch-case factory, adding a new type requires modifying the switch.

- This means it breaks OCP.

- But, this is actually a known limitation of a simple factory (or static factory method) — which is not the same as the Factory Method pattern (GoF) or the Abstract Factory pattern.

 - The idea is:

- ✅ Simple Factory (like our switch example):

- Convenient, easy to understand.

- Breaks OCP because you add case statements.

- ✅ Factory Method pattern / Abstract Factory pattern:

- Solves this by pushing responsibility to subclasses (each subclass can override CreateProduct).

- Now adding a new type means adding a new class — no existing code changes.

### So when is it justified to use Factory?
- ➡️ You use Factory when:

- Object creation is complex, or requires multiple steps, config, or external data.

- You want to centralize creation logic (so you can change it later without touching all new keywords across the codebase).

- You may need to switch which concrete class to instantiate at runtime, based on parameters.

### ✅ Why still use Factory then?
- Because it solves a different problem than Strategy.

- Strategy solves "which algorithm or behavior to execute."

- Factory solves "which concrete object to create."

- Without factories:

- Your code would be full of new PdfDocument(), new WordDocument(), tightly coupling it to concrete classes.

- Changing the instantiation logic everywhere becomes a nightmare.

### 🎯 Final takeaway:

- ✔ Use Strategy to vary behavior.

- ✔ Use Factory to vary instantiation of objects.

- They solve different problems — and in complex systems, you’ll often see them used together. (For example, the factory could create different strategies at runtime.)


```csharp
public interface IDocument
{
    void Print();
}

public class PdfDocument : IDocument
{
    public void Print()
    {
        Console.WriteLine("Printing a PDF document...");
    }
}

public class WordDocument : IDocument
{
    public void Print()
    {
        Console.WriteLine("Printing a Word document...");
    }
}

public class ExcelDocument : IDocument
{
    public void Print()
    {
        Console.WriteLine("Printing an Excel document...");
    }
}

public class DocumentFactory
{
    public IDocument CreateDocument(string type)
    {
        switch (type)
        {
            case "PDF":
                return new PdfDocument();
            case "WORD":
                return new WordDocument();
            case "EXCEL":
                return new ExcelDocument();
            default:
                throw new ArgumentException("Invalid document type.");
        }
    }
}

class Program
{
    static void Main()
    {
        var factory = new DocumentFactory();

        IDocument doc1 = factory.CreateDocument("PDF");
        doc1.Print(); // Printing a PDF document...

        IDocument doc2 = factory.CreateDocument("WORD");
        doc2.Print(); // Printing a Word document...

        IDocument doc3 = factory.CreateDocument("EXCEL");
        doc3.Print(); // Printing an Excel document...
    }
}

```