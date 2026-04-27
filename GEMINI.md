# Core.Console Project Manifest

This file provides persistent context for Gemini CLI to ensure rapid project re-entry and alignment with architectural standards.

## 🏗️ Architectural Overview

- **Pattern:** Console UI Framework with DI and Navigation.
- **UI:** Spectre.Console for ANSI rendering.
- **Reactive:** ReactiveUI + Fody for state management.
- **Testing:** NUnit + Moq.

## 🛠️ State (April 2026)

### Key Features
- **ConsoleApplication**: Main entry point handling the event loop and shutdown.
- **Page Pattern**: Structured views with Menu support.
- **IOC**: `RegisterCore()` extension for Easy DI setup.

### Test Coverage
- **Status**: Initialized.
- **Project**: `PolyhydraGames.Core.Console.Tests` (NUnit).
- **Focus**: Application lifecycle, Navigation, Page processing.

## 📋 Coding Standards
- **Mocking**: Prefer `Moq` for unit tests.
- **UI**: Encapsulate Spectre.Console calls within Display services where possible to maintain testability.
- **Reactive**: Use ReactiveUI for complex state transitions in Console Pages.
