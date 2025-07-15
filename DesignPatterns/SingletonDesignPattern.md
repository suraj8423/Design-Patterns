# Singleton Design Pattern

```csharp
using System;
using System.Runtime.CompilerServices;

namespace SingletonDesignPattern;

public sealed class SingletonClass
{
    private static int Counter = 0;
    private static SingletonClass _instance = null;
    private SingletonClass()
    {
        Counter++;
        Console.WriteLine($"Counter: {Counter}");
    }
    private static readonly object _lock = new object();

    public static SingletonClass GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new SingletonClass();
                }
            }
        }
        return _instance;
    }
}
```

### Why are we using sealed class if we have already made our constructor as private?
- So if we are making the class sealed meaning that from outside we cannot inherit the class but what if we have created a new class inside the SingletonClass there we can inherit from SingletonClass right.

- So if we will create the object of the subclass then we can easily create multiple instance of the SingletonClass. 

- So to save ourselfes from this situation we are making our class sealed.


# Singleton vs Static Class in C#

## 📌 Similarities Between Singleton and Static Class

✅ **Single Instance in Memory**
- Both Singleton and Static Class ensure only one instance exists in memory throughout the lifetime of the application.

✅ **Global State**
- They hold a global state that is accessible throughout the application and is common for all consumers.

✅ **Thread-Safe Implementation**
- Both can be implemented in a thread-safe manner to ensure correctness in multi-threaded scenarios.

---

## 🚀 Differences Between Singleton and Static Class

| Feature | Singleton Class | Static Class |
|---------|-----------------|--------------|
| **Concept Type** | Design Pattern | Language Feature |
| **Instance Creation** | Developer explicitly creates a single instance (via static property or method). | Cannot create an instance explicitly; static class is automatically managed by CLR. |
| **Inheritance** | Can inherit from another class (i.e., can be a child class). Cannot be inherited (i.e., cannot be a parent class). | Cannot inherit from any class nor be inherited (compiler treats it as `abstract sealed`). |
| **Constructor** | Always private to prevent instantiation from outside. | No instance constructor allowed. |
| **Initialization** | Can be lazy (created when needed) or eager (created on program load). | Generally initialized when first loaded by CLR. |
| **Parameter Passing** | Can pass singleton instance as method parameter. | Cannot pass static class as a parameter. |
| **Flexibility** | More flexible due to object-oriented capabilities like interface implementation and dependency injection. | Less flexible, mainly used for utility/helper methods. |

---

## 🔎 Additional Notes

- **Singleton ensures controlled instantiation**, where the same instance is reused everywhere.  
- **Static classes are better suited for utility/helper operations**, like mathematical calculations or extension methods, where maintaining state is not required.
- Choosing between them depends on design needs:
  - Use **Singleton** when you want to maintain state and control instance lifecycle.
  - Use **Static class** for stateless utility logic.

---

✅ **Quick Tip:**  
> Remember, **Singleton is a design pattern (conceptual solution)** whereas **Static class is a C# language feature**. That’s the most fundamental difference.



# Singleton vs Static Class in C#

## 📌 Similarities Between Singleton and Static Class

✅ **Single Instance in Memory**
- Both Singleton and Static Class ensure only one instance exists in memory throughout the lifetime of the application.

✅ **Global State**
- They hold a global state that is accessible throughout the application and is common for all consumers.

✅ **Thread-Safe Implementation**
- Both can be implemented in a thread-safe manner to ensure correctness in multi-threaded scenarios.

---

## 🚀 Differences Between Singleton and Static Class

| Feature | Singleton Class | Static Class |
|---------|-----------------|--------------|
| **Concept Type** | Design Pattern | Language Feature |
| **Instance Creation** | Developer explicitly creates a single instance (via static property or method). | Cannot create an instance explicitly; static class is automatically managed by CLR. |
| **Inheritance** | Can inherit from another class (i.e., can be a child class). Cannot be inherited (i.e., cannot be a parent class). | Cannot inherit from any class nor be inherited (compiler treats it as `abstract sealed`). |
| **Constructor** | Always private to prevent instantiation from outside. | No instance constructor allowed. |
| **Initialization** | Can be lazy (created when needed) or eager (created on program load). | Generally initialized when first loaded by CLR. |
| **Parameter Passing** | Can pass singleton instance as method parameter. | Cannot pass static class as a parameter. |
| **Flexibility** | More flexible due to object-oriented capabilities like interface implementation and dependency injection. | Less flexible, mainly used for utility/helper methods. |

---

## 🔎 Additional Notes

- **Singleton ensures controlled instantiation**, where the same instance is reused everywhere.  
- **Static classes are better suited for utility/helper operations**, like mathematical calculations or extension methods, where maintaining state is not required.
- Choosing between them depends on design needs:
  - Use **Singleton** when you want to maintain state and control instance lifecycle.
  - Use **Static class** for stateless utility logic.

---

✅ **Quick Tip:**  
> Remember, **Singleton is a design pattern (conceptual solution)** whereas **Static class is a C# language feature**. That’s the most fundamental difference.

---

# 🧠 Memory Management: Static Class vs Singleton Class in C#

## 🏗️ Static Class Memory Management

- **Allocation:**  
  Memory for static classes is allocated once when the class is loaded.
- **Location:**  
  Allocated in a special area of memory called the **High-Frequency Heap** (a heap dedicated for static data by the CLR).
- **Lifetime:**  
  - Static class memory exists for the **entire lifetime of the application domain**.  
  - Cleaned up only when the application domain unloads or the application exits.
- **Notes:**  
  Static classes are never instantiated; their members are accessed directly, and their memory footprint is tied to the application lifetime.

---

## 🚀 Singleton Class Memory Management

- **Allocation:**  
  Memory for a singleton instance is allocated on the **managed heap** the first time it is requested (i.e., lazy initialization).
- **Lifetime:**  
  - Memory remains allocated as long as there is a reference to the singleton instance.  
  - Typically, since applications hold references globally, the instance lasts for the application’s lifetime.
- **Garbage Collection:**  
  - Unlike static classes, singleton instances can technically be garbage collected if there are **no more references**.  
  - You could use advanced techniques like **weak references** to allow GC to reclaim the singleton if no longer needed.

---

## 🔎 Summary Table

| Feature                    | Static Class                              | Singleton Class                            |
|-----------------------------|------------------------------------------|-------------------------------------------|
| **Memory Allocation**       | On class load in high-frequency heap     | On first request on managed heap          |
| **Lifetime**                | Entire application domain lifetime       | As long as references exist (typically app lifetime) |
| **Garbage Collection**      | Not applicable (lives till app exits)     | Can be collected if no references exist (with advanced patterns) |

---

✅ **Quick Tip:**  
> For most practical applications, both static classes and singletons live for the duration of the application. The key difference is that singleton memory management still respects .NET's object model and garbage collection.


### Singleton vs Static Class in C#: When to Use Which?
#### Use Singleton when:
- You might need to switch from a single instance to multiple instances in the future without changing the API.
- You require lazy initialization or initialization upon first access.
- The class needs to maintain its state for its lifetime.
- You want the class to implement interfaces or manage inheritance hierarchies.
#### Use Static Class when:
- You are creating utility functions that do not store any state.
- You want a simple and straightforward mechanism to provide global access without any initialization logic.
- You need constants, static configuration settings, or methods that are logically grouped together but do not need to interact with instance data.