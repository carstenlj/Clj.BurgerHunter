# About the code

### `BurgerHunter.Core`
- Contains the main business logic for the burger backend. 
- The `BurgerHunterProcessor` class exposes the main API to consume.

### `BurgerHunter.Mocking`
- Contains mocked implementations of the abstractions defined in the core project. 
- Contains sample data in .json format used by the implementations

### `BurgerHunter.Tests`
- Contains unit tests of the abstraction layers
- Contains end-to-end tests of the `BurgerHunterProcessor`
- Uses XUnit for testing framework

### `BurgerHunter.Web.Api`
- A sample Web API project consuming the `BurgerHunterProcessor`
