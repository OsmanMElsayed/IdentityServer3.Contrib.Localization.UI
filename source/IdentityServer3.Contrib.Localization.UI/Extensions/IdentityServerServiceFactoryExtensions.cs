using System;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;

namespace IdentityServer3.Contrib.Localization.UI.Extensions
{
    public static class IdentityServerServiceFactoryExtensions
    {
        public static void ConfigureLocalizedViewService(this IdentityServerServiceFactory factory)
        {
            var config = new LocalizedViewServiceOptions();
            ConfigureLocalizedViewService(factory, config);
        }

        public static void ConfigureLocalizedViewService(this IdentityServerServiceFactory factory, LocalizedViewServiceOptions config)
        {
            if (factory == null)
            {
                throw new ArgumentException(nameof(factory));
            }
            if (config == null)
            {
                throw new ArgumentException(nameof(config));
            }
            if (factory.ViewService != null)
            {
                throw new InvalidOperationException("A ViewService is already configured");
            }
            
            factory.ViewService = new LocalizedViewServiceRegistration(config);
        }
    }
}
