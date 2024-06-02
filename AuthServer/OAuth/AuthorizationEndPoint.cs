using AuthServer.Models;
using Microsoft.AspNetCore.DataProtection;
using System.Text.Json;
using System.Web;

namespace AuthServer.OAuth
{
    public class AuthorizationEndPoint
    {
        public static IResult Handle
       (HttpRequest req, IDataProtectionProvider provider)
        {
            req.Query.TryGetValue("response_type", out var responseType);
            req.Query.TryGetValue("client_id", out var clientId);
            req.Query.TryGetValue("code_challenge", out var codeChallenge);
            req.Query.TryGetValue("code_challenge_method", out var codeChallengeMethod);
            req.Query.TryGetValue("redirect_uri", out var redirectUri);
            req.Query.TryGetValue("state", out var state);
            req.Query.TryGetValue("scope", out var scope);
            var protector = provider.CreateProtector("oatuh");
            var code = new AuthCode()
            {
                ClientId = clientId,
                CodeChallenge = codeChallenge,
                CodeChallengeMethod = codeChallengeMethod,
                ReturnUri = redirectUri,
                Expiry = DateTime.UtcNow.AddMinutes(7)
            };

            var codeString = protector.Protect(JsonSerializer.Serialize(code));
            return Results.Redirect(redirectUri + $"?code={codeString}&& state={state} && iss={HttpUtility.UrlEncode("https://localhost:7000")}");
        }
    }
}
