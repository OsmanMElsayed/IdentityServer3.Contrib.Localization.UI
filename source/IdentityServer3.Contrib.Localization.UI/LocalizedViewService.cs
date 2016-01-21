using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.ViewModels;

namespace IdentityServer3.Contrib.Localization.UI
{
    public class LocalizedViewService : DefaultViewService
    {
        public LocalizedViewService(DefaultViewServiceOptions config, LocalizedViewLoader viewLoader) : base(config, viewLoader)
        {
        }

        protected override Task<Stream> Render(CommonViewModel model, string page, IEnumerable<string> stylesheets, IEnumerable<string> scripts)
        {

            return base.Render(model, page, stylesheets, scripts);
        }
    }
}
