# Contributing to Talks API

First off, thank you for considering contributing to Talks API! 🎉

## 📋 Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Getting Started](#getting-started)
- [How Can I Contribute?](#how-can-i-contribute)
- [Development Process](#development-process)
- [Style Guidelines](#style-guidelines)
- [Testing Guidelines](#testing-guidelines)
- [Commit Messages](#commit-messages)
- [Pull Request Process](#pull-request-process)

## 📜 Code of Conduct

This project and everyone participating in it is governed by our Code of Conduct. By participating, you are expected to uphold this code. Please report unacceptable behavior to the project maintainers.

### Our Standards

- **Be respectful** and inclusive of differing viewpoints and experiences
- **Be collaborative** and constructive in your feedback
- **Focus on what is best** for the community
- **Show empathy** towards other community members

## 🚀 Getting Started

### Prerequisites

- .NET 9.0 SDK or later
- Git
- Visual Studio 2022, VS Code, or Rider
- Basic knowledge of C# and ASP.NET Core

### Setting Up Your Development Environment

1. **Fork the repository** on GitHub
2. **Clone your fork** locally:
   ```bash
   git clone https://github.com/YOUR-USERNAME/Talks.git
   cd Talks
   ```
3. **Add upstream remote**:
   ```bash
   git remote add upstream https://github.com/ORIGINAL-OWNER/Talks.git
   ```
4. **Install dependencies**:
   ```bash
   dotnet restore
   ```
5. **Build the solution**:
   ```bash
   dotnet build
   ```
6. **Run tests** to ensure everything works:
   ```bash
   dotnet test
   ```

## 🤝 How Can I Contribute?

### Reporting Bugs

Before creating bug reports, please check existing issues to avoid duplicates. When creating a bug report, include:

- **Clear descriptive title**
- **Detailed description** of the issue
- **Steps to reproduce** the behavior
- **Expected behavior**
- **Actual behavior**
- **Screenshots** (if applicable)
- **Environment details** (.NET version, OS, etc.)

### Suggesting Enhancements

Enhancement suggestions are tracked as GitHub issues. When creating an enhancement suggestion, include:

- **Clear descriptive title**
- **Detailed description** of the proposed functionality
- **Use cases** and examples
- **Why this enhancement would be useful**

### Your First Code Contribution

Unsure where to begin? Look for issues labeled:
- `good first issue` - Simple issues for newcomers
- `help wanted` - Issues where we need community help

## 💻 Development Process

### Creating a Branch

Always create a new branch for your work:

```bash
# Get latest changes from upstream
git fetch upstream
git checkout main
git merge upstream/main

# Create a new branch
git checkout -b feature/your-feature-name
# or
git checkout -b fix/your-bug-fix
```

### Branch Naming Convention

- `feature/` - New features (e.g., `feature/add-speaker-endpoint`)
- `fix/` - Bug fixes (e.g., `fix/null-reference-error`)
- `docs/` - Documentation changes (e.g., `docs/update-readme`)
- `refactor/` - Code refactoring (e.g., `refactor/service-layer`)
- `test/` - Adding or updating tests (e.g., `test/controller-tests`)

## 🎨 Style Guidelines

### C# Coding Standards

- Follow [Microsoft's C# Coding Conventions](https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/coding-conventions)
- Use **PascalCase** for class names, method names, and properties
- Use **camelCase** for local variables and parameters
- Use **meaningful names** that describe the purpose
- Keep methods **small and focused** (single responsibility)
- Add **XML documentation comments** for public APIs

### Example

```csharp
/// <summary>
/// Retrieves all talks from the repository.
/// </summary>
/// <returns>A collection of talk DTOs.</returns>
public IEnumerable<TalksDTO> GetTalksAsync()
{
    var talks = _talkRepository.GetTalksAsync();
    return _mapper.Map<IEnumerable<TalksDTO>>(talks);
}
```

### Project Structure

- Place domain entities in `Talks.Domain`
- Place business logic in `Talks.Service`
- Place API controllers in `Talks.Api/Controllers`
- Place tests in `Talks.Tests` with corresponding folder structure

## 🧪 Testing Guidelines

### Writing Tests

- **Write tests** for all new features and bug fixes
- Use **xUnit** for test framework
- Use **Moq** for mocking dependencies
- Use **FluentAssertions** for readable assertions
- Follow **AAA pattern**: Arrange, Act, Assert

### Test Naming Convention

```csharp
[Fact]
public void MethodName_Scenario_ExpectedBehavior()
{
    // Arrange
    
    // Act
    
    // Assert
}
```

### Running Tests

Before submitting a PR, ensure:

```bash
# All tests pass
dotnet test

# Build succeeds
dotnet build

# No warnings (treat warnings as errors in CI)
dotnet build /p:TreatWarningsAsErrors=true
```

## 📝 Commit Messages

### Format

```
<type>(<scope>): <subject>

<body>

<footer>
```

### Types

- `feat`: New feature
- `fix`: Bug fix
- `docs`: Documentation changes
- `style`: Code style changes (formatting, missing semi-colons, etc.)
- `refactor`: Code refactoring
- `test`: Adding or updating tests
- `chore`: Maintenance tasks

### Examples

```
feat(api): add endpoint to retrieve talk by id

Add new GET endpoint at /api/talks/{id} to retrieve a single talk.
Includes service layer implementation and unit tests.

Closes #123
```

```
fix(service): handle null reference in GetTalksAsync

Add null checks to prevent NullReferenceException when repository
returns null. Update tests to cover this scenario.

Fixes #456
```

## 🔄 Pull Request Process

### Before Submitting

1. ✅ Update documentation if needed
2. ✅ Add or update tests
3. ✅ Ensure all tests pass
4. ✅ Update CHANGELOG.md (if applicable)
5. ✅ Ensure your code follows style guidelines
6. ✅ Rebase your branch on latest main

### Submitting a Pull Request

1. **Push your branch** to your fork:
   ```bash
   git push origin feature/your-feature-name
   ```

2. **Open a Pull Request** on GitHub with:
   - Clear title describing the change
   - Description explaining what and why
   - Reference to related issues (e.g., "Closes #123")
   - Screenshots (if applicable)

3. **PR Template** should include:
   ```markdown
   ## Description
   Brief description of changes
   
   ## Type of Change
   - [ ] Bug fix
   - [ ] New feature
   - [ ] Breaking change
   - [ ] Documentation update
   
   ## Testing
   - [ ] All tests pass
   - [ ] Added new tests
   
   ## Checklist
   - [ ] Code follows style guidelines
   - [ ] Self-reviewed code
   - [ ] Commented hard-to-understand areas
   - [ ] Updated documentation
   ```

### Review Process

- Maintainers will review your PR
- Address any feedback or requested changes
- Once approved, your PR will be merged
- Your contribution will be credited in the release notes

## 🎯 Additional Notes

### Keep Your Fork Updated

Regularly sync your fork with upstream:

```bash
git fetch upstream
git checkout main
git merge upstream/main
git push origin main
```

### Need Help?

- Check existing documentation
- Look at closed issues and PRs for similar problems
- Ask questions in issue comments
- Reach out to maintainers

## 🙏 Thank You!

Your contributions make this project better for everyone. We appreciate your time and effort! 💙

---

**Happy Contributing!** 🚀
