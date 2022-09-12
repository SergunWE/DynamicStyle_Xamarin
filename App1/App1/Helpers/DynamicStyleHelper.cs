using App1.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1.Helpers
{
    public static class DynamicStyleHelper
    {
        private static double _referenceWidth = 1080;
        private static double _referenceDensity = 2.75;
        private static double _displayCoef = 0;

        private static ResourceDictionary _resources;
        private static ResourceDictionary _baseStyle;

        static DynamicStyleHelper()
        {
            _baseStyle = new BaseStyle();
        }

        public static void CalculateAndSetValues(double width, double density, ResourceDictionary resources)
        {
            SetResources(CalculateDynamicValues(width, density, resources));
        }

        public static ResourceDictionary CalculateDynamicValues(double width, double density, ResourceDictionary resources)
        {
            _referenceWidth = width;
            _referenceDensity = density;
            _resources = resources;
            CalculateDisplayCoef();
            CalculateValues();
            return _resources;
        }

        public static void SetResources(ResourceDictionary resources)
        {
            foreach (var resource in resources)
            {
                ResourceHelper.SetResource(resource.Key, resource.Value);
            }
        }

        private static void CalculateDisplayCoef()
        {
            double d = DeviceDisplay.MainDisplayInfo.Density;
            double w = DeviceDisplay.MainDisplayInfo.Width;
            _displayCoef = w / d / (_referenceWidth / _referenceDensity);
        }

        private static void CalculateValues()
        {
            foreach (var resource in _resources.ToList())
            {
                switch (resource.Value)
                {
                    case double _:
                        CalculateDouble(resource.Key);
                        break;
                    case Thickness _:
                        CalculateThickness(resource.Key);
                        break;
                    default:
                        _resources[resource.Key] = resource.Value;
                        break;
                }
            }
        }

        private static void CalculateDouble(string resourceName)
        {
            _resources[resourceName] = (double)_resources[resourceName] * _displayCoef;
        }

        private static void CalculateThickness(string resourceName)
        {
            Thickness thickness = (Thickness)_resources[resourceName];
            thickness.Left = thickness.Left * _displayCoef;
            thickness.Right = thickness.Right * _displayCoef;
            thickness.Top = thickness.Top * _displayCoef;
            thickness.Bottom = thickness.Bottom * _displayCoef;
            _resources[resourceName] = thickness;
        }
    }
}
