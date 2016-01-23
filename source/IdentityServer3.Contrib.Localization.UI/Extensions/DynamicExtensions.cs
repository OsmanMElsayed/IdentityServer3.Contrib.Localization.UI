using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;

namespace IdentityServer3.Contrib.Localization.UI.Extensions
{
    internal static class DynamicExtensions
    {
        public static dynamic ToDynamic(this object value)
        {
            IDictionary<string, object> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
                expando.Add(property.Name, property.GetValue(value));

            return (ExpandoObject) expando;
        }
    }
}
