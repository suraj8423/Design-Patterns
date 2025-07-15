# Liscov Substitution principle

## Definition
- Subclasses should be substituted for their base classes.

```csharp
Let say there is a class A and class B, and A <------- B (meaning B is inheriting from A).
If I am replacing object of A to B in client code it should not break the code or give any unexpected behaviour.
```