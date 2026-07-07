# GH-500 Code Scanning Demo

> **Warning:** This repository is intentionally insecure for GitHub Advanced Security demonstrations. It contains unsafe code patterns and secret-like values for training purposes only. Never use this repository as a production template.

## GHAS Demos

### Code Scanning (CodeQL)

- The intentionally vulnerable Razor Page lives at `Pages/Vulnerable.cshtml` and `Pages/Vulnerable.cshtml.cs`.
- Browse to `/Vulnerable` in a local run and use query string parameters to exercise the intentionally insecure sinks.
- `.github/workflows/codeql.yml` is configured to analyze the repository with the `security-extended` and `security-and-quality` query suites for a richer demo.

### Secret Scanning + Push Protection

- Follow [docs/demos/secret-scanning.md](docs/demos/secret-scanning.md).
- The existing intentionally hardcoded key in `Pages/Index.cshtml` is left in place as a demo finding.

### Dependency Review / Dependabot

- Follow [docs/demos/dependency-review.md](docs/demos/dependency-review.md).
- `.github/workflows/dependency-review.yml` gates pull requests to `main`.
- `.github/dependabot.yml` configures weekly updates for NuGet packages and GitHub Actions.
