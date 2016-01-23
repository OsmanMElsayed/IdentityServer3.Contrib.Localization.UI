using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using IdentityServer3.Contrib.Localization.UI.Extensions;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.ViewModels;

namespace IdentityServer3.Contrib.Localization.UI
{
    public class LocalizedViewService : DefaultViewService
    {
        public LocalizedViewService(LocalizedViewServiceOptions config, LocalizedViewLoader viewLoader) 
            : base(config, viewLoader)
        {
        }

        protected object BuildModelWithLanguageInfo(CommonViewModel model, string page, IEnumerable<string> stylesheets, IEnumerable<string> scripts)
        {
            var data = base.BuildModel(model, page, stylesheets, scripts);
            
            //Extend data object & add language & dir info
            var dynamicData = data.ToDynamic();

            var currentUiCulture = Thread.CurrentThread.CurrentUICulture;
            dynamicData.languageCode = currentUiCulture.TwoLetterISOLanguageName;
            dynamicData.languageTextDirection = currentUiCulture.TextInfo.IsRightToLeft ? "rtl" : "ltr";

            return dynamicData;
        }

        protected override async Task<Stream> Render(CommonViewModel model, string page, IEnumerable<string> stylesheets, IEnumerable<string> scripts)
        {
            var data = BuildModelWithLanguageInfo(model, page, stylesheets, scripts);

            string html = await LoadHtmlTemplate(page);
            html = FormatHtmlTemplate(html, data);

            return html.ToStream();
        }
    }
}
