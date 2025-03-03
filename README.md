# Design Patterns in ASP.NET Core

This project demonstrates the implementation of various design patterns in ASP.NET Core, following the tutorials from [DotNetTutorials](https://dotnettutorials.net/course/dot-net-design-patterns/).

## Project Structure

- **DesignPatternsNet.API**: ASP.NET Core Web API project that exposes endpoints to demonstrate the usage of various design patterns.
- **DesignPatternsNet.Creational**: Class library containing implementations of creational design patterns.
- **DesignPatternsNet.Structural**: Class library containing implementations of structural design patterns.
- **DesignPatternsNet.Behavioral**: Class library containing implementations of behavioral design patterns.
- **DesignPatternsNet.Common**: Class library containing common interfaces, models, and utilities used across the solution.

## Design Patterns Implemented

### Creational Patterns
- Factory Method
- Abstract Factory
- Builder
- Prototype
- Singleton
- Fluent Interface

### Structural Patterns
- Adapter
- Bridge
- Composite
- Decorator
- Facade
- Flyweight
- Proxy

### Behavioral Patterns
- Chain of Responsibility
- Command
- Interpreter
- Iterator
- Mediator
- Memento
- Observer
- State
- Strategy
- Template Method
- Visitor

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio or your preferred IDE
3. Build the solution
4. Run the API project
5. Use the Swagger UI to test the various design pattern implementations

## API Endpoints

Each design pattern has its own controller with endpoints that demonstrate the pattern's usage. The Swagger UI provides documentation for all available endpoints.

## Dependencies

- .NET 9.0
- ASP.NET Core 9.0

## SOLID Principles

All implementations adhere to SOLID principles:
- **S**ingle Responsibility Principle
- **O**pen/Closed Principle
- **L**iskov Substitution Principle
- **I**nterface Segregation Principle
- **D**ependency Inversion Principle
