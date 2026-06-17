How It Works
IExistingJsonParser (Target): Defines the standard interface your application uses.

LegacyXmlParser (Adaptee): Contains the actual complex parsing logic you don't want to rewrite, but it requires XML structure and specific parameters.

XmlToJsonAdapter (Adapter): Implements IJsonParser. When ParseJson() is called, it translates the incoming data into XML, maps any extra required parameters, and passes the call to the legacy parser.

Why This Helps
Instead of writing a massive amount of new code or modifying the fragile legacy class (violating the Open/Closed Principle), you simply wrote a lightweight wrapper that makes two incompatible systems shake hands.

The implementation of the Adapter Design Pattern in this scenario directly aligns with several core **SOLID** principles and general object-oriented design philosophies.

Here is a breakdown of the specific design principles followed in the code:

---

### 1. Open/Closed Principle (OCP)

> *“Software entities should be open for extension, but closed for modification.”*

* **How it’s followed:** If you need to integrate your system with yet another third-party parser (e.g., a Legacy CSV or YAML parser), you don’t have to touch or modify the existing working `Program` client code, nor do you change the `LegacyXmlParser`. You simply create a new adapter class (e.g., `CsvToJsonAdapter`) that implements `IJsonParser`.
* **The Benefit:** It prevents regression bugs in older, fragile, or third-party code because you never have to alter their source files to make them compatible with new requirements.

### 2. Single Responsibility Principle (SRP)

> *“A class should have only one reason to change.”*

* **How it’s followed:** * The `LegacyXmlParser` has one job: parsing XML data.
* The `XmlToJsonAdapter` has one job: handling the data conversion and bridging the gap between JSON and XML.
* The `Program` client has one job: executing high-level business logic.


* **The Benefit:** If the way data is converted from JSON to XML changes in the future, you only update the adapter. The core XML parsing logic remains entirely decoupled and untouched.

### 3. Dependency Inversion Principle (DIP)

> *“Depend upon abstractions, not concretions.”*

* **How it’s followed:** The client code (`Program`) interacts entirely with the `IJsonParser` abstraction rather than a specific concrete implementation. It doesn't know (or care) whether the underlying engine processing the request is a native JSON handler or an adapter wrapping a 15-year-old legacy XML system.
* **The Benefit:** This decouples the high-level policy of your system from low-level implementation details, making the codebase highly testable and flexible.

---

### Summary of Benefits

| Principle | Where it lives in your code | Why it matters |
| --- | --- | --- |
| **Open/Closed** | Leaving `LegacyXmlParser` unmodified while extending its utility. | Zero risk of breaking legacy code. |
| **Single Responsibility** | Separating translation logic (`Adapter`) from core processing logic (`Adaptee`). | Easier maintenance and cleaner code. |
| **Dependency Inversion** | Programming the client to use `IJsonParser`. | Makes components interchangeable and easy to mock for unit tests. |

Why it DOES follow LSP
The Liskov Substitution Principle states that objects of a superclass (or interface) should be replaceable with objects of its subclasses without breaking the application. In our design:

The Abstraction: IJsonParser promises to take a JSON string and parse it.

The Adapter: XmlToJsonAdapter implements IJsonParser. It takes the JSON string, converts it to XML behind the scenes, and processes it.

If your client code expects an IJsonParser, you can pass it a native JSON parser, or you can pass it the XmlToJsonAdapter. In both cases, the client code calls .ParseJson(data), the data is processed, and the program continues running smoothly. Because the adapter can seamlessly stand in for the interface without crashing the client, LSP is fully satisfied.

Why some people think it violates LSP
The confusion usually arises from one of two scenarios:

1. Expecting "Perfect" Behavioral Mirroring
For LSP to hold true, the subtype must honor the behavioral contract of the parent.
If your IJsonParser interface dictates that a failure must throw a JsonParsingException, but your legacy adapter throws an XmlException, the client code might crash because it wasn't catching XmlException.

The Verdict: That specific implementation violates LSP. To fix it, the Adapter must catch the XmlException and wrap/translate it into a JsonParsingException to honor the interface's contract.

2. The "Square/Rectangle" Analogy Confusion
People often associate LSP violations with forcing incompatible behaviors together (like making a Square inherit from Rectangle). They look at an Adapter and say: "An XML Parser isn't a JSON Parser! You are forcing them together!"

But that is exactly what makes the pattern work:

The LegacyXmlParser does not inherit from IJsonParser (that would violate LSP).

Instead, the Adapter acts as a translator. The Adapter itself is a JSON handler from the client's perspective because it accepts JSON. What it does internally to fulfill that promise is its own business.

The Golden Rule of LSP in Adapters
As long as your Adapters adhere to these three rules, they will always follow LSP:

Accept the same inputs: Don't require the client to pass XML to a JSON interface.

Return the same outputs: If the interface expects a specific object structure back, the adapter must map the legacy output to match it.

Mimic the same side-effects: Don't throw unexpected, unhandled legacy exceptions that break the client's catch blocks.