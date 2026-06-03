# Azure Pipelines → GitHub Actions Migration

Status: Drafted. The existing Azure pipeline has been inventoried and a GitHub Actions parity plan is captured below. Publishing or package-push steps remain gated until the required secrets and variables are confirmed.

## Current Azure pipeline inventory

| Area | Current behavior in `build.yml` | Notes |
| --- | --- | --- |
| Trigger | Pushes to `refs/heads/main` when paths under `src` change | No PR trigger is defined today. |
| Versioning | `name: 1.0.0.$(rev:r)` | Azure increments the run number into the package version string. |
| Variables | `Project.Path = **/PolyhydraGames.Core.Console.csproj` and `Project.Config = release` | The project path resolves to the library project under `src/`. |
| Agent pool | `pool.name = Default` | `vmImage` is commented out, so the pipeline expects a self-managed/default pool. |
| Restore | `DotNetCoreCLI@2 restore` against `$(Project.Path)` with feed restore ID `015fc12f-cd63-4ab4-8d6a-dc889e53bf70` | Restore depends on the Azure Artifacts feed. |
| Build | `DotNetCoreCLI@2 build --no-restore` | Uses Release configuration. |
| Pack | `DotNetCoreCLI@2 pack --no-build` with `versioningScheme: byBuildNumber` | Produces package artifacts from the same project. |
| Publish to internal feed | `NuGetCommand@2 push` to feed `015fc12f-cd63-4ab4-8d6a-dc889e53bf70` | Requires the Azure feed identity/permissions. |
| Publish to NuGet.org | `NuGetCommand@2 push` using external credentials named `Nuget Org` | This is the second publish target. |
| Test step | Not present | The current pipeline does not run `dotnet test`. |
| Discord notification | Documented in `docs/setup.md` as disabled | Keep it out of the draft until a secret mapping is confirmed. |

## Draft GitHub Actions equivalent

The draft below mirrors the current build/pack/publish shape, but intentionally stops before any live package publication. That keeps the migration safe until the GitHub secret/variable mapping is confirmed.

```yaml
name: ci-dotnet

on:
  push:
    branches:
      - main
    paths:
      - "src/**"
      - "PolyhydraGames.Core.Console.sln"
      - "build.yml"
      - ".github/workflows/ci-dotnet.yml"
  workflow_dispatch:

env:
  DOTNET_NOLOGO: true
  CONFIGURATION: Release
  PROJECT_PATH: src/PolyhydraGames.Core.Console.csproj

jobs:
  build_pack:
    name: Build and pack
    runs-on: ubuntu-latest
    steps:
      - name: Checkout
        uses: actions/checkout@v4

      - name: Setup .NET
        uses: actions/setup-dotnet@v4
        with:
          dotnet-version: 10.0.x

      - name: Restore
        run: dotnet restore "${PROJECT_PATH}"

      - name: Build
        run: dotnet build "${PROJECT_PATH}" --configuration "${CONFIGURATION}" --no-restore

      - name: Pack
        run: dotnet pack "${PROJECT_PATH}" --configuration "${CONFIGURATION}" --no-build -p:Version=1.0.0.${{ github.run_number }}

      - name: Upload package artifacts
        uses: actions/upload-artifact@v4
        with:
          name: nuget-packages
          path: |
            **/*.nupkg
            !**/*.symbols.nupkg

  publish:
    name: Publish packages
    needs: build_pack
    if: false # enable only after the feed/API secrets are confirmed and mapped
    runs-on: ubuntu-latest
    steps:
      - name: Placeholder
        run: echo "Publish steps stay disabled until secrets and variables are approved."
```

## Secret / variable confirmation gate

Before the publish job is enabled, confirm the GitHub-side mapping for the Azure-specific values below:

- Azure Artifacts feed restore ID `015fc12f-cd63-4ab4-8d6a-dc889e53bf70`
- Azure Artifacts publish permissions for the internal Polyhydra feed
- NuGet.org API key / publish credential
- Any Discord notification secret that should replace the disabled Azure pipeline step

## Follow-up checklist

- [x] Inventory the current Azure pipeline behavior.
- [x] Draft a GitHub Actions workflow shape that mirrors build/pack behavior.
- [x] Keep publish steps disabled until secrets and variables are confirmed.
- [ ] Confirm the GitHub secret/variable mapping for feed publishing.
- [ ] Decide whether test execution should be added to the migration parity baseline.
- [ ] Create the real `.github/workflows/` workflow once the publish gate is cleared.
