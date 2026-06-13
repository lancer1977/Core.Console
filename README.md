# Core.Console

[![Build Status](https://img.shields.io/github/actions/workflow/user/lancer1977/Core.Console/.github/workflows/ci.yml/badge.svg)](https://github.com/lancer1977/Core.Console/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## Tags

- dotnet
- core
- core-console
- docs
- testing
- console

## 🚀 Overview
`Core.Console` provides a structured framework for building .NET console applications. It integrates dependency injection, configuration, logging, and a page-based navigation pattern using Spectre.Console for rich ANSI rendering.

## ✨ Key Features
*   **Console UI Framework**: Enables building interactive console applications.
*   **Dependency Injection**: Built-in support for `Microsoft.Extensions.DependencyInjection`.
*   **Page Pattern**: Structured views with menu support for navigation.
*   **Spectre.Console Integration**: Leverages Spectre.Console for advanced ANSI rendering and UI elements.
*   **ReactiveUI Support**: Integrates ReactiveUI for managing complex state transitions in Console Pages.
*   **Build Notifications**: Configurable Discord notifications via Azure DevOps pipeline secrets.

## 🏗️ Architecture
A Console UI Framework with DI and Navigation. Key components include `ConsoleApplication` for the event loop, a `Page` pattern for structured views, and `RegisterCore()` for DI setup. UI elements are encapsulated within Display services for testability.

### 🛠️ Technology Stack
*   **Language**: C#
*   **Framework**: .NET 8+
*   **UI Library**: Spectre.Console
*   **Reactive**: ReactiveUI + Fody
*   **Testing**: NUnit + Moq
*   **Project Structure**: Single `.sln` file found; `.csproj` files were absent, suggesting reliance on global build properties or older project formats.

## 🚦 Getting Started

### Prerequisites
*   .NET 8 SDK (or compatible version)
*   An IDE that supports C# development (e.g., VS Code, Visual Studio)

### Installation
```bash
# Clone the repository
git clone git@github.com:lancer1977/Core.Console.git
cd Core.Console

# Restore NuGet packages (likely handled by global build properties/SLN file)
dotnet restore
```

## 📖 Usage & Education
The project provides a minimal example demonstrating DI setup, page creation, and menu handling. Key steps include:
1.  Creating a `ServiceCollection`.
2.  Registering Core services using `services.RegisterCore()`.
3.  Adding custom services and pages.
4.  Building the `ServiceProvider` and running the application.

Refer to the [Sample Host Application](./samples/SampleHost/) for a complete example.

## 🌐 Deployment & Hosting
*   **Repo**: [Core.Console](https://github.com/lancer1977/Core.Console)
*   **Hosting Platform**: GitHub.
*   **Build Notifications**: Discord via Azure DevOps secrets.

## 📦 Packages & Dependencies
*   **NuGet**: Package name and details TBD, as `.csproj` files were not found. Likely depends on `Spectre.Console` and `ReactiveUI`.
*   **Local Projects**: `Core.Interfaces`, `Core.Extensions` (Likely dependencies).

## 🔗 Related Projects
*   Other `Core.*` libraries within the Polyhydra Games ecosystem.

## 📚 Documentation & Resources
*   **Features**: [Docs/Features](./docs/features/README.md)
*   **CI/CD**: [GitHub Actions](https://github.com/lancer1977/Core.Console/actions)

## Docs

- [Roadmap Index](./docs/roadmaps/README.md)

---
*This README was generated based on project metadata and description.*
