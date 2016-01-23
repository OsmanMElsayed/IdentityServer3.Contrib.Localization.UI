using System;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services.Default;

namespace IdentityServer3.Contrib.Localization.UI
{
    /// <summary>
    /// Registration for the localized view service.
    /// </summary>
    public class LocalizedViewServiceRegistration : DefaultViewServiceRegistration<LocalizedViewService>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedViewServiceRegistration"/> class.
        /// </summary>
        public LocalizedViewServiceRegistration()
            : this(new LocalizedViewServiceOptions())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocalizedViewServiceRegistration"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public LocalizedViewServiceRegistration(LocalizedViewServiceOptions options)
            : base(options)
        {
            if (options == null) throw new ArgumentNullException(nameof(options));

            AdditionalRegistrations.Add(new Registration<LocalizedViewServiceOptions>(options));

            var localizedViewLoader = string.IsNullOrEmpty(options.CustomViewDirectory)
                    ? new LocalizedViewLoader()
                    : new LocalizedViewLoader(options.CustomViewDirectory);
            options.ViewLoader = new Registration<IViewLoader>(localizedViewLoader);
            AdditionalRegistrations.Add(new Registration<LocalizedViewLoader>(localizedViewLoader));
        }
    }
}
