# 🏦 Facade Design Pattern

## 📖 General Description
The **Facade Design Pattern** is a **structural pattern** that provides a **simplified interface** to a complex subsystem. Instead of exposing the client to multiple classes and their intricate interactions, the Facade offers a unified entry point that delegates requests to the appropriate subsystem components.

It’s like a **front desk in a bank or hotel**: customers interact with one representative (Facade), who coordinates with multiple departments behind the scenes.

---

## 🧩 Design Principles Used
The Facade pattern embodies several **object-oriented design principles**:

1. **Single Responsibility Principle (SRP)**  
   - The Facade class has one responsibility: provide a simplified interface to the subsystem.  
   - Subsystems retain their own responsibilities (e.g., `AccountService`, `LoanService`).

2. **Open/Closed Principle (OCP)**  
   - Subsystems can be extended (new services added) without modifying the Facade’s interface.  
   - The Facade can expose new methods while keeping existing ones intact.

3. **Dependency Inversion Principle (DIP)**  
   - Clients depend on the Facade abstraction rather than concrete subsystem classes.  
   - This reduces coupling between client code and subsystem details.

4. **Encapsulation**  
   - Internal complexity of subsystems is hidden.  
   - Clients don’t need to know how credit checks or loan approvals are performed.

---

## ✅ Pros
- **Simplifies usage**: Clients interact with one unified interface instead of multiple subsystems.
- **Reduces coupling**: Clients are shielded from subsystem changes.
- **Improves readability**: High-level operations are expressed clearly (`ApplyLoan`, `OpenAccount`).
- **Encapsulation of complexity**: Internal details remain hidden, improving maintainability.

---

## ❌ Cons
- **Potential over-simplification**: Facade may hide important functionality that advanced clients need.
- **Risk of God Object**: If the Facade grows too large, it may become bloated and violate SRP.
- **Performance overhead**: Extra abstraction layer may add slight overhead in some cases.
- **Limited flexibility**: Clients may lose fine-grained control over subsystems.

---

## 🏦 Example: Banking System

### Subsystems
- `AccountService` → Handles account creation.  
- `LoanService` → Manages loan applications.  
- `PaymentService` → Processes payments.  
- `CreditService` → Checks customer credit scores.  

### Facade
- `BankFacade` → Provides simplified methods:
  - `OpenAccount(Customer)`
  - `ApplyLoan(Customer, amount)`
  - `MakeTransaction(Customer, amount)`

### Customer Object
Encapsulates customer details:
```csharp
public class Customer
{
    public string Name { get; }
    public int CreditScore { get; }

    public Customer(string name, int creditScore)
    {
        Name = name;
        CreditScore = creditScore;
    }
}
