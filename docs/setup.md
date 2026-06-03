# Core.Console Setup

## CI/CD Pipeline

The current source of truth is `build.yml`, an Azure DevOps pipeline.
A GitHub Actions parity draft is documented in `docs/roadmap/github_actions.md`.

The migration notes deliberately stop short of enabling package publication until the GitHub-side secrets and variables are confirmed.

### Discord Webhook Integration

The old Discord notification step is documented as disabled in `build.yml`.
If that notification returns in GitHub Actions, map the secret key into a GitHub secret or environment variable first, then wire the notification step to read from that secret.

For example, if the webhook URL is `https://discord.com/api/webhooks/123456789/abcdefg`, the secret should store the key portion (`abcdefg`) and never the full webhook URL.

**Important:** Keep the notification secret out of source control and do not publish the package pipeline until the feed and webhook mappings are approved.
