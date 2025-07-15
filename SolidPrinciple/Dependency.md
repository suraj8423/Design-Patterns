
# Dependency Inversion Principle (DIP) - SOLID in C#

## 🔷 What is the Dependency Inversion Principle?

**Definition:**  
> High-level modules should not depend on low-level modules. Both should depend on abstractions.  
> Abstractions should not depend on details. Details should depend on abstractions.

## ❗Why is this important?
If high-level classes depend directly on low-level details, any change in low-level classes forces changes in high-level classes too. This leads to tight coupling, harder testing, and inflexibility.

## 🎯 Real-world Analogy
Imagine a plug point that supports different types of chargers (Android, iPhone, etc.).  
Instead of wiring directly to a specific charger, you define a standard interface like `ICharger`.

This way, your wall socket (high-level module) depends on an interface (abstraction), not on the specific charger type.

---

## 👎 Without DIP (Bad Design)

```
public class LightBulb {
    public void TurnOn() {
        Console.WriteLine("LightBulb: Turned On");
    }
}

public class Switch {
    private LightBulb _bulb;

    public Switch() {
        _bulb = new LightBulb(); // direct dependency on concrete class
    }

    public void Operate() {
        _bulb.TurnOn();
    }
}
```

### ❌ Problems:
- `Switch` directly depends on the `LightBulb`.
- Cannot switch to another type of device without changing `Switch`.
- Difficult to test.

---

## ✅ With DIP (Good Design using Abstraction)

### Step 1: Create Interface

```
public interface IDevice {
    void TurnOn();
}
```

### Step 2: Implement LightBulb

```
public class LightBulb : IDevice {
    public void TurnOn() {
        Console.WriteLine("LightBulb: Turned On");
    }
}
```

### Step 3: Update Switch to depend on IDevice

```
public class Switch {
    private IDevice _device;

    public Switch(IDevice device) {
        _device = device; // Constructor Injection
    }

    public void Operate() {
        _device.TurnOn();
    }
}
```

### Step 4: Use in Main Program

```
class Program {
    static void Main(string[] args) {
        IDevice bulb = new LightBulb();
        Switch mySwitch = new Switch(bulb);
        mySwitch.Operate(); // Output: LightBulb: Turned On
    }
}
```

---

## 🧪 Unit Testable

You can now create a fake/mock for testing:

```
public class FakeDevice : IDevice {
    public void TurnOn() {
        Console.WriteLine("FakeDevice: Testing Only");
    }
}
```

---

## 💬 Summary

| Without DIP                     | With DIP                          |
|--------------------------------|-----------------------------------|
| High-level depends on low-level| Both depend on interfaces         |
| Hard to test or extend         | Easy to mock, extend, and reuse   |
| Tightly coupled                | Loosely coupled and flexible      |

---

## 🚀 Key Concepts

- DIP is about decoupling high-level policies from low-level implementations.
- Achieved through **Dependency Injection (DI)**.
- Promotes coding to **interfaces/abstract classes** instead of concrete classes.

---
