using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityServer3.Contrib.Localization.UI.Sample.Configuration
{
    public class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            return new[]
            {
                ////////////////////////
                // identity scopes
                ////////////////////////

                StandardScopes.OpenId,
                StandardScopes.Profile,
                StandardScopes.Email,
                StandardScopes.Address,
                StandardScopes.OfflineAccess,
                StandardScopes.RolesAlwaysInclude,
                StandardScopes.AllClaims,
            };
        }
    }
}