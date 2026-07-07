# Dependency Review and Dependabot Demo

> This repository is intentionally insecure for GitHub Advanced Security demonstrations. Never reuse these patterns in a real application.

## What was added

- `.github/workflows/dependency-review.yml` runs `actions/dependency-review-action` on pull requests to `main`.
- `.github/dependabot.yml` configures weekly updates for NuGet packages and GitHub Actions.

## 1. Run the dependency review demo

1. Create a demo branch from `main`.
2. Edit `WebApp1.csproj` and temporarily downgrade `Microsoft.EntityFrameworkCore.SqlServer` to a known-vulnerable version for the demo PR.
3. Open a pull request targeting `main`.
4. Wait for the **Dependency Review** workflow to run.
5. Show the failing check and the PR comment summary explaining the vulnerable dependency change.

## 2. Show Dependabot

1. Ensure **Dependency graph** and **Dependabot alerts** are enabled in **Settings → Advanced Security / Code security**.
2. From the repository **Insights** or **Security** views, show the dependency graph and any alerts.
3. Wait for Dependabot's weekly schedule or trigger a manual demo by adjusting an outdated dependency in a separate branch.
4. Show the resulting Dependabot pull request or alert once GitHub detects it.

## 3. Suggested talking points

- Dependency Review blocks risky dependency changes before merge.
- Dependabot keeps both application dependencies and GitHub Actions updated.
- The PR summary comment helps reviewers understand why a dependency change is risky.
