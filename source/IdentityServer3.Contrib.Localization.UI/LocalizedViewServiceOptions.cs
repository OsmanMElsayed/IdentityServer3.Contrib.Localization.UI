using IdentityServer3.Core.Services.Default;

namespace IdentityServer3.Contrib.Localization.UI
{
    public class LocalizedViewServiceOptions : DefaultViewServiceOptions
    {
        public string CustomViewDirectory { get; set; }
    }
}
