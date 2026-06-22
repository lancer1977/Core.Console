# Core.Console Setup

## CI/CD Pipeline

The current source of truth is `.github/workflows/ci.yml`.
That workflow restores from GitHub Packages and `nuget.org`, then builds and packs the console library.

### Package Auth

The workflow uses `GHCR_TOKEN` from GitHub Secrets to authenticate against GitHub Packages during restore.

### Discord Webhook Integration

There is no active Discord notification step in the workflow today.
If one is added later, keep the webhook secret in GitHub Secrets or an environment secret and avoid committing the full webhook URL.
