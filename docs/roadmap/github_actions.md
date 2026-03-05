# Azure Pipelines → GitHub Actions Migration

Status: Identified as a repo that should standardize on GitHub Actions.

## Goal
Move CI/CD from Azure Pipelines to GitHub Actions (where realistic), then retire overlapping Azure pipeline definitions.

## Proposed Work
- [ ] Inventory current Azure pipeline behavior (build/test/pack/publish/deploy)
- [ ] Create equivalent workflow(s) in `.github/workflows/`
- [ ] Port triggers (push/PR/tags/schedules)
- [ ] Port secrets/variables from Azure DevOps to GitHub Actions secrets/vars
- [ ] Port artifacts and package publishing steps
- [ ] Validate branch protections/check names
- [ ] Run side-by-side for 1–2 runs and compare outputs
- [ ] Disable/remove Azure pipeline once parity is confirmed

## Suggested Starter Workflows
- `ci-dotnet.yml` (restore, build, test)
- `publish-nuget.yml` (optional, on tags/releases)

## Notes
Auto-generated on 2026-03-02 at user request.
