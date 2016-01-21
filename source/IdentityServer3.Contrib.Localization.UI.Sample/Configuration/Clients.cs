using System.Collections.Generic;
using IdentityServer3.Core;
using IdentityServer3.Core.Models;

namespace IdentityServer3.Contrib.Localization.UI.Sample.Configuration
{
    public class Clients
    {
        public static List<Client> Get()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientName = "UI Localization Demo",
                    Enabled = true,

                    ClientId = "localization",
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret".Sha256())
                    },

                    Flow = Flows.AuthorizationCode,

                    RequireConsent = true,
                    AllowRememberConsent = true,

                    RedirectUris = new List<string>
                    {
                        // MVC code client manual
                        "http://localhost:57874",
                    },

                    AllowedScopes = new List<string>
                    {
                        Constants.StandardScopes.OpenId,
                        Constants.StandardScopes.OfflineAccess
                    },

                    AccessTokenType = AccessTokenType.Reference,
                }
            };
        }
    }
}