# The Command Design Pattern in C#

The **Command Design Pattern** is a behavioral design pattern that turns a request into a stand-alone object containing all information about the request. 

This transformation allows you to parameterize clients with different requests, queue or log requests, and support undoable operations.

---

## The Core Concept: The Restaurant Analogy

Think of the pattern like ordering food at a restaurant:
1. **The Client (You):** You decide what you want to eat.
2. **The Invoker (The Waiter):** Takes your order and writes it down on a notepad.
3. **The Command (The Notepad Slip):** Encapsulates your request as a physical object. It contains all details about what needs to be made.
4. **The Receiver (The Chef):** Reads the slip and cooks the meal. The chef doesn't need to know who ordered it; they just execute the instructions on the slip.

---

## Core Components

| Component | Responsibility |
| :--- | :--- |
| **Command** | An interface or abstract class declaring the execution interface (`Execute()`, `Undo()`). |
| **Concrete Command** | Implements the Command interface; defines a binding between a Receiver and an action. |
| **Receiver** | Knows how to perform the operations associated with carrying out a request (the actual business logic). |
| **Invoker** | Asks the command to carry out the request. It holds the command object(s). |

---

## Key Design Principles Used

The Command pattern relies heavily on standard object-oriented design principles:

* **Encapsulation:** It encapsulates a method invocation, its parameters, and its target receiver into a single concrete object.
* **Low Coupling (Decoupling):** The **Invoker** (e.g., UI button, scheduler) has zero knowledge of what the **Receiver** (e.g., database, text engine) actually does. They only talk via the `ICommand` abstraction.
* **Single Responsibility Principle (SRP):** * The *Invoker* is only responsible for execution timing and history tracking.
    * The *Command* is only responsible for mapping actions to the receiver.
    * The *Receiver* is only responsible for mutating the internal business state.
* **Open/Closed Principle (OCP):** You can add new commands (like `DeleteTextCommand` or `CutCommand`) without changing any existing code inside the `HistoryManager` or the `TextEditor`.
* **Dependency Inversion Principle (DIP):** High-level orchestration layers do not depend on low-level business rule implementations. Both depend entirely on the `ICommand` and `ITextEditorReceiver` abstractions.

---

## Pros and Cons

### Pros
* **Decoupling:** Complete separation between the class triggering the action and the class executing it.
* **Easy Undo/Redo:** Storing executable command objects sequentially in standard data collections (like stacks) makes tracking history clean and structured.
* **Macro Commands:** You can easily chain multiple operations together into a composite command sequence that executes seamlessly.
* **Deferred Actions:** Commands can be scheduled, placed in queues, or serialized to be run across network nodes at a later time.

### Cons
* **Class Explosion:** Every discrete action requires its own concrete class. In vast software applications, this can quickly result in hundreds of tiny files.
* **Increased Complexity:** Introducing multiple layers of interfaces, invokers, and commands can be massive over-engineering for simple applications.
* **State Management Hurdles:** If the command execution depends heavily on capturing a complex snapshot of the application state at an exact point in time, handling edge cases during deep undo loops can become error-prone.

---

## C# Implementation Example (With Undo/Redo Stacks)

Here is a practical C# example of a text editor system that supports robust Undo and Redo operations using `Stack<T>`.

### 1. The Receiver Interface & Implementation
```csharp
public interface ITextEditorReceiver
{
    string Content { get; set; }
    void Print();
}

public class TextEditor : ITextEditorReceiver
{
    private string _content;

    public TextEditor()
    {
        _content = "";
    }

    public string Content
    {
        get { return _content; }
        set { _content = value; }
    }

    public void Print()
    {
        Console.WriteLine("Current Text: \"{0}\"", _content);
    }
}