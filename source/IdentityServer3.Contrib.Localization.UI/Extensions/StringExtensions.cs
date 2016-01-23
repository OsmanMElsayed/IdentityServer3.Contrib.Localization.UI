using System;
using System.IO;

namespace IdentityServer3.Contrib.Localization.UI.Extensions
{
    internal static class StringExtensions
    {
        public static Stream ToStream(this string s)
        {
            if (s == null) throw new ArgumentNullException("s");

            var ms = new MemoryStream();
            var sw = new StreamWriter(ms);
            sw.Write(s);
            sw.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            return ms;
        }
    }
}
