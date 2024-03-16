using PolyhydraGames.Extensions;
using Xamarin.Essentials;

namespace PolyhydraGames.Core.Console.Services;

public static class AuthenticatorExtensions
{
    public static IExternalUserRecord ToExternalUserRecord(this WebAuthenticatorResult result)
    {
        return new ExternalUserRecord
        {
            UserId = result.Properties["userid"].ToGuid(), // result.IdToken,
            AuthToken = result.AccessToken,
            Email = result.RefreshToken,
            Provider = result.Properties["provider"]
        };
    }
}