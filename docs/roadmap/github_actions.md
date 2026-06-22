# GitHub Actions Workflow Notes

Status: Active. The GitHub Actions workflow is live and handles restore, build, and pack from GitHub Packages.

## Current Azure pipeline inventory

| Area | Current behavior in `.github/workflows/ci.yml` | Notes |
| --- | --- | --- |
| Trigger | Pushes and pull requests against `main` | Path filter is limited to `src/**` and the workflow file. |
| Restore | `dotnet restore` with a generated `NuGet.Config` | Restores from GitHub Packages and `nuget.org`. |
| Build | `dotnet build --no-restore` | Uses Release configuration. |
| Pack | `dotnet pack --no-build` | Produces package artifacts from the same project. |

## Follow-up checklist

- [x] Confirm the current GitHub Actions workflow shape.
- [x] Document GitHub Packages auth and pack behavior.
- [ ] Decide whether test execution should be added to the workflow.
- [ ] Add publish-on-tag if package release automation is desired.
