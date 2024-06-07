using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IDServer
{
    public class IdentityConfiguration
    {
        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
        new TestUser
        {
            SubjectId = "1144",
            Username = "admin",
            Password = "admin",
            Claims =
            {
                new Claim(JwtClaimTypes.Name, "Admin"),
                new Claim(JwtClaimTypes.GivenName, "Admin"),
                new Claim(JwtClaimTypes.FamilyName, "Admin"),
                new Claim( JwtClaimTypes.Role,"0"),
            }
        },
                new TestUser
        {
            SubjectId = "1",
            Username = "player",
            Password = "player",
            Claims =
            {
                new Claim(JwtClaimTypes.Name, "player"),
                new Claim(JwtClaimTypes.GivenName, "player"),
                new Claim(JwtClaimTypes.FamilyName, "player"),
                new Claim( JwtClaimTypes.Role,"1"),
            }
        }
        };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
        new ApiScope("myApi.scope", new string[]{ JwtClaimTypes.Role}),
            };
        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {
        new ApiResource("myApi" , new[]{ JwtClaimTypes.Role})
        {
            Scopes = new List<string>{ "myApi.scope" },
            ApiSecrets = new List<Secret>{ new Secret("secret".Sha256()) }
        }
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientId = "client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "myApi.scope" }
                },
            };
    }
}
