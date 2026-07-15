# Observer Design Pattern

The **Observer Design Pattern** is a behavioral design pattern that defines a one-to-many dependency between objects so that when one object (the Subject/Observable) changes state, all its dependents (Observers) are notified and updated automatically.

This pattern is ideal for scenarios where multiple objects need to stay synchronized with changes in a central object without creating tight coupling.

---

## 📰 The News Agency Analogy

Think of the pattern like a news agency distribution system:

1. **The Subject (The News Agency):** The source of information that publishes news updates.  
2. **The Observer (News Subscribers):** Multiple subscribers who want to receive news as soon as it's published.  
3. **The Subscription (The Relationship):** Subscribers register themselves with the agency; when news breaks, they're automatically notified.  
4. **The Update (The Event):** When news is published, all subscribed observers receive the information immediately without being asked.  

👉 The news agency doesn’t need to know who the subscribers are or what they do with the news—it just broadcasts it.

---

## 🔑 Core Components

| Component | Responsibility |
| :--- | :--- |
| **Subject/Observable** | Defines the interface for attaching and detaching observers; notifies all observers of state changes. |
| **Concrete Subject** | Stores the state of interest to `ConcreteObserver` objects; sends notifications to its observers when the state changes. |
| **Observer** | Defines the update interface for objects that should be notified of changes in a subject. |
| **Concrete Observer** | Implements the update interface; maintains a reference to a `ConcreteSubject` object; stores state consistent with the subject's; implements the observer's update interface. |

---

## ⚙️ Key Design Principles

The Observer pattern leverages several core object-oriented design principles:

- **Encapsulation:** The Subject encapsulates its state and how it notifies observers.  
- **Loose Coupling:** The Subject only knows observers implement the `IObserver` interface; it doesn’t depend on their concrete types.  
- **Single Responsibility Principle (SRP):**  
  - The *Subject* manages