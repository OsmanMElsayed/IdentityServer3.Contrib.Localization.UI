using IdentityServer3.Contrib.Localization.UI.Sample.Configuration;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;
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

            //Configure localized views
            var viewServiceOptions = new DefaultViewServiceOptions
            {
                ViewLoader = new Registration<IViewLoader>(new LocalizedViewLoader())
            };
            factory.ConfigureDefaultViewService(viewServiceOptions);

            var options = new IdentityServerOptions
            {
                Factory = factory,
                RequireSsl = false
            };

            appBuilder.UseIdentityServer(options);
        }
    }
}