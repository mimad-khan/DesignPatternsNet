# Design Patterns in ASP.NET Core

This project demonstrates the implementation of various design patterns in ASP.NET Core, following the tutorials from [DotNetTutorials](https://dotnettutorials.net/course/dot-net-design-patterns/).

## Project Structure

- **DesignPatternsNet.API**: ASP.NET Core Web API project that exposes endpoints to demonstrate the usage of various design patterns.
- **DesignPatternsNet.Creational**: Class library containing implementations of creational design patterns.
- **DesignPatternsNet.Structural**: Class library containing implementations of structural design patterns.
- **DesignPatternsNet.Behavioral**: Class library containing implementations of behavioral design patterns.
- **DesignPatternsNet.Common**: Class library containing common interfaces, models, and utilities used across the solution.
- **DesignPatternsNet.Tests**: Unit tests for all implemented design patterns.

## Design Patterns Implemented

### Creational Patterns
These patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

#### Factory Method
- **Purpose**: Creates objects without specifying the exact class to create.
- **Implementation**: Defines an interface for creating an object, but lets subclasses decide which class to instantiate.
- **Example**: `DocumentCreator` creates different types of documents (PDF, Word) without client code knowing the specific class.

#### Abstract Factory
- **Purpose**: Creates families of related objects without specifying their concrete classes.
- **Implementation**: Provides an interface for creating families of related objects without specifying their concrete classes.
- **Example**: `ThemeFactory` creates related UI elements (buttons, textboxes) that share the same theme (Light or Dark).

#### Builder
- **Purpose**: Separates the construction of complex objects from their representation.
- **Implementation**: Allows constructing complex objects step by step using the same construction code.
- **Example**: `ComputerBuilder` constructs a computer with various components (CPU, RAM, Storage, etc.).

#### Prototype
- **Purpose**: Creates new objects by copying existing ones.
- **Implementation**: Creates new objects by cloning existing instances, avoiding the overhead of creating new instances from scratch.
- **Example**: `DocumentPrototype` allows cloning existing documents to create new ones with similar properties.

#### Singleton
- **Purpose**: Ensures a class has only one instance and provides a global point of access to it.
- **Implementation**: Restricts the instantiation of a class to one single instance and provides a global access point.
- **Example**: `Logger` ensures only one logging instance exists throughout the application.

### Structural Patterns
These patterns deal with object composition or how entities can use each other.

#### Adapter
- **Purpose**: Allows objects with incompatible interfaces to collaborate.
- **Implementation**: Wraps an existing class with a new interface to make it compatible with client code.
- **Example**: `LegacySystemAdapter` adapts a legacy API to work with modern code.

#### Bridge
- **Purpose**: Separates an abstraction from its implementation so they can vary independently.
- **Implementation**: Splits a large class into two separate hierarchies—abstraction and implementation—which can be developed independently.
- **Example**: `RemoteControl` and `Device` hierarchies allow different remotes to control different devices.

#### Composite
- **Purpose**: Composes objects into tree structures to represent part-whole hierarchies.
- **Implementation**: Lets clients treat individual objects and compositions of objects uniformly.
- **Example**: `FileSystemItem` represents both files and directories in a file system.

#### Decorator
- **Purpose**: Adds new responsibilities to objects dynamically without altering their structure.
- **Implementation**: Wraps objects to add new behaviors at runtime.
- **Example**: `NotificationDecorator` adds additional notification channels to a base notification service.

#### Facade
- **Purpose**: Provides a simplified interface to a complex subsystem.
- **Implementation**: Defines a higher-level interface that makes the subsystem easier to use.
- **Example**: `OrderProcessingFacade` simplifies interactions with multiple subsystems (inventory, payment, shipping).

#### Proxy
- **Purpose**: Provides a surrogate or placeholder for another object to control access to it.
- **Implementation**: Controls access to the original object, allowing operations before or after requests reach the original object.
- **Example**: `ImageProxy` loads heavy images only when needed, showing a placeholder until then.

### Behavioral Patterns
These patterns deal with algorithms and the assignment of responsibilities between objects.

#### Chain of Responsibility
- **Purpose**: Passes a request along a chain of handlers until one of them handles it.
- **Implementation**: Avoids coupling the sender of a request to its receiver by giving more than one object a chance to handle the request.
- **Example**: `AuthenticationHandler` chains different authentication methods (token, basic, OAuth).

#### Command
- **Purpose**: Turns a request into a stand-alone object containing all information about the request.
- **Implementation**: Encapsulates a request as an object, allowing parameterization of clients with different requests and queue or log requests.
- **Example**: `AddItemCommand` encapsulates operations on a collection, enabling undo functionality.

#### Observer
- **Purpose**: Defines a subscription mechanism to notify multiple objects about events.
- **Implementation**: Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified.
- **Example**: `Subject` notifies multiple `Observer` objects when its state changes.

#### Strategy
- **Purpose**: Defines a family of algorithms and makes them interchangeable.
- **Implementation**: Enables selecting an algorithm at runtime from a family of algorithms.
- **Example**: `SortingStrategy` allows switching between different sorting algorithms at runtime.

#### Template Method
- **Purpose**: Defines the skeleton of an algorithm, deferring some steps to subclasses.
- **Implementation**: Defines the program skeleton in a method, deferring some steps to subclasses without changing the algorithm's structure.
- **Example**: `ReportGenerator` defines steps for generating reports, with specific report types implementing certain steps.

#### Visitor
- **Purpose**: Separates algorithms from the objects on which they operate.
- **Implementation**: Lets you add further operations to objects without modifying them.
- **Example**: `DocumentVisitor` performs operations on different document elements without changing their classes.

#### Memento
- **Purpose**: Captures and externalizes an object's internal state without violating encapsulation.
- **Implementation**: Allows restoring an object to a previous state (undo via rollback).
- **Example**: `EditorMemento` saves and restores the state of a text editor.

#### State
- **Purpose**: Allows an object to alter its behavior when its internal state changes.
- **Implementation**: Lets an object change its behavior when its internal state changes, appearing to change its class.
- **Example**: `OrderState` changes the behavior of an order based on its current state (new, processing, shipped).

#### Mediator
- **Purpose**: Reduces coupling between classes by centralizing external communications.
- **Implementation**: Reduces chaotic dependencies between objects by restricting direct communications and forcing objects to collaborate via a mediator object.
- **Example**: `ChatMediator` enables communication between users without them referencing each other directly.

#### Iterator
- **Purpose**: Provides a way to access elements of a collection sequentially without exposing its underlying representation.
- **Implementation**: Separates the traversal of a collection from its structure.
- **Example**: `CustomCollection` provides iterators to traverse its elements in different ways.

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Build the solution
4. Run the API project
5. Use the Swagger UI to test the various design pattern implementations

## API Endpoints

Each design pattern has its own controller with endpoints that demonstrate the pattern's usage. The Swagger UI provides documentation for all available endpoints.

## Unit Tests

The project includes comprehensive unit tests for all implemented design patterns. Run the tests to verify the correct implementation of each pattern.

## Dependencies

- .NET 9.0
- ASP.NET Core 9.0
- xUnit (for testing)

## SOLID Principles

All implementations adhere to SOLID principles:
- **S**ingle Responsibility Principle: Each class has only one reason to change
- **O**pen/Closed Principle: Classes are open for extension but closed for modification
- **L**iskov Substitution Principle: Derived classes must be substitutable for their base classes
- **I**nterface Segregation Principle: Clients should not be forced to depend on methods they do not use
- **D**ependency Inversion Principle: High-level modules should not depend on low-level modules
