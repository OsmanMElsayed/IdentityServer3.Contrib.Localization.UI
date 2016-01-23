using IdentityServer3.Contrib.Localization.UI.Extensions;
using IdentityServer3.Contrib.Localization.UI.Sample.Configuration;
using IdentityServer3.Core.Configuration;
using Owin;

namespace IdentityServer3.Contrib.Localization.UI.Sample
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var factory = new IdentityServerServiceFactory()
                        .UseInMemoryUsers(Users.Get())
                        .UseInMemoryClients(Clients.Get())
                        .UseInMemoryScopes(Scopes.Get());

            //Configure localized view service
            factory.ConfigureLocalizedViewService();

            var options = new IdentityServerOptions
            {
                Factory = factory,
                RequireSsl = false
            };

            appBuilder.UseIdentityServer(options);
        }
    }
}