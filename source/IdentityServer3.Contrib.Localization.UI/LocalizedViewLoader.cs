﻿using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Thinktecture.IdentityServer.Core.Services.Default;

namespace IdentityServer3.Contrib.Localization.UI
{
    public class LocalizedViewLoader : IViewLoader
    {
        readonly FileSystemViewLoader file;
        readonly EmbeddedAssetsViewLoader embedded;

        public LocalizedViewLoader()
            : this(GetDefaultDirectory())
        {
        }

        public LocalizedViewLoader(string directory)
        {
            file = new FileSystemViewLoader(directory);
            embedded = new EmbeddedAssetsViewLoader();
        }

        static string GetDefaultDirectory()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            path = Path.Combine(path, "assets");
            return path;
        }

        public string Load(string name)
        {
            var value = file.Load(name);
            if (value == null)
            {
                value = embedded.Load(name);
            }
            return TranslatorHelper.Instance.Translate(value);
        }
    }
}
