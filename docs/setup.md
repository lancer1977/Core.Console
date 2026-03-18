# Core.Console Setup

## CI/CD Pipeline

The CI/CD pipeline is defined in `build.yml` and uses an Azure DevOps pipeline.

### Discord Webhook Integration

The pipeline sends a notification to a Discord channel upon successful build completion. This uses the `ado-discord-webhook` task.

To configure the webhook, you must create a pipeline variable in Azure DevOps named `Discord.WebhookKey` and set its value to the secret key part of your Discord webhook URL.

For example, if your webhook URL is `https://discord.com/api/webhooks/123456789/abcdefg`, then the value of `Discord.WebhookKey` should be `abcdefg`.

**Important:** Make sure to mark this variable as a secret in Azure DevOps to prevent it from being exposed in logs.
