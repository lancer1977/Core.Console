# Code Health

Last reviewed: 2026-06-27

## Native Validation

```bash
dotnet test PolyhydraGames.Core.Console.sln --configuration Release --verbosity minimal
dotnet list PolyhydraGames.Core.Console.sln package --outdated
devstudio validate --repo /home/lancer1977/code/Core.Console
```

## Current Findings

- Tests pass locally: 14 passed.
- CI now restores, builds, tests, and packs the package path.
- Dependency drift is limited to `SixLabors.ImageSharp` 3.1.12 -> 4.0.0; this is intentionally deferred until SixLabors licensing is configured.
- Generated Dev Studio runtime state remains untracked.

## Follow-Up Backlog

- Define the public API surface and add more focused regression tests for highest-risk console navigation helpers.
- Decide whether this repo should adopt central package management with the rest of the Core family.
- Add richer sample snippets for common downstream host scenarios.
