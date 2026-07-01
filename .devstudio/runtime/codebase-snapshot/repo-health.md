# Repo Health Recommendations

Generated: `2026-06-23T17:09:47.614523+00:00`
Model lane: `auto`
Preparedness input: `/mnt/data/lancer1977/code/Core.Console/.devstudio/runtime/codebase-snapshot/preparedness.json`

- Scope roots: `/mnt/data/lancer1977/code/Core.Console`
- Repositories scanned: `1`
- Scope matches: `1`

- Repositories reviewed: `1`
- Docs attention: `1`
- Test attention: `0`
- Dependency warnings: `1`
- Dependency watchlist: `0`
- CI attention: `0`
- Branch attention: `0`
- Dirty worktree attention: `1`
- Artifact attention: `0`
- Freshness attention: `0`
- Backlog pressure: `0`

## Top recommendations
- `/mnt/data/lancer1977/code/Core.Console` — readiness `82` / priority `49`
  - Themes: `dependencies, docs, worktree`
  - Recommendations: Restore the required docs spine and make the repo's purpose/setup easy to find again., Commit, stash, or clean the worktree before starting the next slice., No obvious .NET lock or central-version file is present; run `dotnet list package --outdated` and decide whether this repo should adopt central package management before the next slice.
  - Dependency status: `warn`
    - `dotnet` manifests: `samples/SampleHost/SampleHost.csproj, src/PolyhydraGames.Core.Console.csproj, test/PolyhydraGames.Core.Console.Tests/PolyhydraGames.Core.Console.Tests.csproj`
      - advice: No obvious .NET lock or central-version file is present; run `dotnet list package --outdated` and decide whether this repo should adopt central package management before the next slice.

## Escalation note

Use the local lane for broad triage and the premium lane only on the shortlist. If you want to burn Codex, do it after this report has reduced the search space.
