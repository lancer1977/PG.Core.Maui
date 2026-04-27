# Core.Maui

[![Build Status](https://img.shields.io/github/actions/workflow/user/lancer1977/PG.Core.Maui/.github/workflows/ci.yml/badge.svg)](https://github.com/lancer1977/PG.Core.Maui/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 🚀 Overview
This repository contains the core .NET MAUI application framework and related components for the Polyhydra Games ecosystem. It provides foundational elements for building cross-platform applications.

## ✨ Key Features
*   **Cross-Platform UI**: Enables development of UIs for mobile and desktop platforms using .NET MAUI.
*   **Core Framework**: Provides essential services and structures for application development.
*   **Testability**: Includes testing projects and adhering to quality standards.

## 🏗️ Architecture
The project utilizes a multi-project structure with shared test projects, likely following common .NET architectural patterns. The presence of `.sln` and `.csproj` files indicates a standard .NET project setup.

### 🛠️ Technology Stack
*   **Language**: C#
*   **Framework**: .NET MAUI, .NET 8+
*   **Key Libraries**: Likely includes ReactiveUI and other core Polyhydra libraries.

## 🚦 Getting Started

### Prerequisites
*   .NET 8 SDK (or compatible version)
*   .NET MAUI workload installed (`dotnet workload install maui`)
*   Visual Studio or VS Code with C#/.NET MAUI extensions.

### Installation
```bash
# Clone the repository
git clone git@github.com:lancer1977/PG.Core.Maui.git
cd PG.Core.Maui

# Restore NuGet packages (standard .NET MAUI project)
dotnet restore
```

## 📖 Usage & Education
Usage involves integrating the `Core.Maui` components into a .NET MAUI application. Refer to the `Core.Maui.App` project (if present) or other Polyhydra projects consuming this library for specific examples.

## 🌐 Deployment & Hosting
*   **Repo**: [PG.Core.Maui](https://github.com/lancer1977/PG.Core.Maui)
*   **Hosting Platform**: GitHub.

## 📦 Packages & Dependencies
*   **NuGet**: `PolyhydraGames.Core.Maui` (Package name inferred from project structure)
*   **Local Projects**: `Core.Interfaces`, `Core.Extensions` (Likely dependencies)

## 🔗 Related Projects
*   Other `Core.*` libraries within the Polyhydra Games ecosystem.

## 📚 Documentation & Resources
*   **Features**: [Docs/Features](./docs/features/README.md)
*   **CI/CD**: [GitHub Actions](https://github.com/lancer1977/PG.Core.Maui/actions)

---
*This README was generated based on project metadata and description.*
