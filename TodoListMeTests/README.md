
# TodoListMeTests

## Project Overview

This project is an automated test suite for [TodoListMe](https://todolistme.net/), a task management application. The tests are written using **SpecFlow** for **Behavior-Driven Development (BDD)**, along with **Selenium WebDriver** for UI automation. The test suite validates core functionalities such as task creation, deletion, list management, and sorting.

## Table of Contents
- [Technologies Used](#technologies-used)
- [Project Structure](#project-structure)
- [Test Selection](#test-selection)
- [Installation and Setup](#installation-and-setup)
- [Running Tests](#running-tests)
- [Running Specific Test Cases](#running-specific-test-cases)
- [Contributing](#contributing)
- [License](#license)

## Technologies Used

- **C#** - Primary programming language for automation.
- **SpecFlow** - BDD framework for writing test scenarios.
- **Selenium WebDriver** - Browser automation tool.
- **MSTest** - Test execution framework.
- **Git & GitHub** - Version control and repository hosting.

## Project Structure

```
TodoListMeTests/
│── Documentation/                # Contains test case selection reasoning
│── Features/                     # Contains feature files written in Gherkin
│   ├── TodoList.feature           # BDD feature file for test scenarios
│── Pages/                         # Page Object Model (POM) for UI elements
│   ├── TodoListPage.cs
│── StepDefinitions/               # Step Definitions for feature files
│   ├── TodoListSteps.cs
│── TestResults/                   # Stores test execution reports
│── .gitignore                      # Git ignore file
│── README.md                       # Project documentation
│── TodoListMeTests.csproj           # Project configuration
│── UnitTest1.cs                     # Sample unit test
```

## Test Selection

### Top 2 Test Cases Selected:

1. **Create a new task in "Today's Tasks" list**
   - Ensures that users can add tasks successfully to their default task list.
   - Validates that the task appears correctly after being added.

2. **Delete a newly created task from "Today's Tasks" list**
   - Ensures that users can remove tasks from their to-do list.
   - Validates that the deleted task no longer appears in the task list.

These tests were prioritized because they cover fundamental task management functionalities. Many other test cases (e.g., sorting, marking as done, copying lists) can be indirectly validated through the execution of these core test cases.

For detailed reasoning on skipped test cases, refer to the `TestCaseSelectionReasoning.txt` file in the `Documentation` folder.

## Installation and Setup

### Prerequisites

- **Install .NET SDK**: [Download .NET SDK](https://dotnet.microsoft.com/en-us/download)
- **Install Chrome**: Required for Selenium WebDriver
- **Install SpecFlow & MSTest**: Run the following command:

  ```sh
  dotnet add package SpecFlow.MSTest
  dotnet add package Selenium.WebDriver
  dotnet add package SpecFlow.Tools.MsBuild.Generation
  ```

### Cloning the Repository


git clone https://github.com/ahmad161050/TodoListMeTests.git
cd TodoListMeTests
```

## Running Tests

To execute all tests, use:

```sh
dotnet test
```

## Running Specific Test Cases

To run **only the top 2 tests**, use:

```sh
dotnet test --filter "Name~CreateANewTask"
```

```sh
dotnet test --filter "Name~DeleteANewTask"
```

## Contributing

Contributions are welcome! Please follow these steps:

1. **Fork the repository**  
2. **Create a feature branch**  
   ```sh
   git checkout -b new-feature
   ```
3. **Make your changes and commit**  
   ```sh
   git commit -m "Added new test case for sorting"
   ```
4. **Push to GitHub and open a pull request**  
   ```sh
   git push origin new-feature
   ```

## License

This project is open-source and available under the MIT License.

---
```