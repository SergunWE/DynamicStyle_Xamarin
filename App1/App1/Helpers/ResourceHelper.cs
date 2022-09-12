using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1.Helpers
{
    public static class ResourceHelper
    {
        public static void SetResource<T>(string resourceName, T value)
        {
            Application.Current.Resources[resourceName] = value;
        }

        public static object GetResource(string keyName)
        {
            if (Application.Current.Resources.TryGetValue(keyName, out var retVal))
            {
                return retVal;
            }
            return null;
        }
    }
}
