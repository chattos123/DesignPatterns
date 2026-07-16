# Flyweight Design Pattern

The **Flyweight Design Pattern** is a structural design pattern focused on optimization. It reduces memory usage and improves performance when dealing with a massive number of similar objects by sharing common data instead of duplicating it across instances.

---

## 1. Intrinsic vs. Extrinsic State

The cornerstone of the Flyweight pattern is separating an object's state into two categories:

- **Intrinsic State:** Constant, uniform, and independent of context. Immutable and sharable across instances.  
- **Extrinsic State:** Unique to each instance, dependent on context. Managed externally and passed into methods at runtime.

---

## 2. Components and Responsibilities

### Flyweight (Interface / Abstract Class)
- **Responsibility:** Defines the contract for handling extrinsic state.  
- **Characteristic:** Declares a method signature that accepts extrinsic state as a parameter.

### ConcreteFlyweight
- **Responsibility:** Implements the Flyweight interface and stores **intrinsic state**.  
- **Characteristic:** Immutable and sharable across contexts; unaware of extrinsic state.

### FlyweightFactory
- **Responsibility:** Manages creation and caching of flyweights.  
- **Characteristic:** Returns existing flyweights from its pool or creates new ones if none match.

### Context (Client)
- **Responsibility:** Maintains or computes **extrinsic state** and references a shared `ConcreteFlyweight`.  
- **Characteristic:** Supplies unique contextual data (e.g., coordinates, indices).

---

## 3. Real-World Use Cases

- **Game Particle Systems:** Shared textures for particles; extrinsic state defines position, velocity, lifespan.  
- **Typography & Word Processors:** Shared glyphs and fonts; extrinsic state defines character positions.  
- **Mapping Applications:** Shared icons and labels; extrinsic state defines coordinates of POIs.

---

## 4. Architectural Design Principles

- **SRP:** Flyweight handles shared properties; Context manages unique state.  
- **OCP:** New flyweights can be added without modifying factory or client code.  
- **SoC:** Separates static data from dynamic context-specific data.

---

## 5. Pros and Cons

### ✅ Pros
- Significant RAM reduction (up to 80–90%).  
- Fewer live objects → reduced GC overhead.  
- Centralized control over shared styles.

### ❌ Cons
- Increased CPU overhead (extrinsic state must be passed each time).  
- Higher architectural complexity.  
- Strict immutability required; accidental mutation can corrupt all contexts.

---

## 6. Example: Text Editor Walkthrough

- **`ICharacterFlyweight` (Flyweight Interface):** Declares `Render(int position)` method.  
- **`CharacterFormat` (ConcreteFlyweight):** Stores intrinsic data like `Symbol`, `FontName`, `FontSize`.  
- **`CharacterFactory` (FlyweightFactory):** Uses a dictionary to cache and reuse character formats.  
- **`Document` (Context/Client):** Holds a list of flyweight references, passing extrinsic state (positions) during rendering.

---