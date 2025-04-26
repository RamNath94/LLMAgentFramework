# LLMAgent Project

## Overview
The LLMAgent project is a .NET-based solution designed to implement a Page Object Model (POM) framework for automated testing. It includes various components such as pages, tests, and utilities to facilitate efficient and maintainable test automation.

## Project Structure

```
LLMAgent/
├── BasePage.cs
├── Class1.cs
├── LLMAgent.sln
├── POMFramework.csproj
├── bin/
├── obj/
├── Pages/
│   └── PracticeFormPage.cs
├── POMFramework/
│   ├── BasePage.cs
│   ├── POMFramework.csproj
│   ├── ReportManager.cs
│   ├── Pages/
│   │   └── PracticeFormPage.cs
│   └── Tests/
│       ├── ManualTestCases.txt
│       └── PracticeFormTests.cs
└── Tests/
    └── FormSubmissionTest.cs
```

### Key Components

- **BasePage.cs**: Contains the base class for all page objects.
- **PracticeFormPage.cs**: Represents the page object for the practice form.
- **ReportManager.cs**: Manages test reporting.
- **PracticeFormTests.cs**: Contains test cases for the practice form.
- **FormSubmissionTest.cs**: Includes tests for form submission functionality.

## Prerequisites

- .NET 9.0 SDK
- Visual Studio or any compatible IDE

## Getting Started

1. Clone the repository:
   ```bash
   git clone <repository-url>
   ```

2. Open the solution file `LLMAgent.sln` in Visual Studio.

3. Build the solution to restore dependencies and compile the project.

4. Run the tests using the Test Explorer in Visual Studio or via the command line:
   ```bash
   dotnet test
   ```

## Folder Details

- **POMFramework**: Contains the core framework files, including base classes, page objects, and utilities.
- **Pages**: Houses the page object classes.
- **Tests**: Includes test cases and manual test documentation.

## Dependencies

The project uses the following dependencies:
- EPPlus
- Microsoft.Extensions.Configuration
- Newtonsoft.Json
- NUnit

## Contributing

1. Fork the repository.
2. Create a new branch for your feature or bug fix:
   ```bash
   git checkout -b feature-name
   ```
3. Commit your changes and push to your fork.
4. Submit a pull request.

## License

This project is licensed under the MIT License. See the LICENSE file for details.

## Contact

For any inquiries or support, please contact [Ramanatha Kamath](mailto:ramanatha.kamath@example.com).
