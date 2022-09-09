﻿using App1.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App1
{
    public class DynamicStyleHelper
    {
        private const double REFERENCE_WIDTH = 1080;
        private const double REFERENCE_DENSITY = 2.75;
        private static double _displayCoef = 0;

        private static string[] _fontSizeValues = { "simpleFontSize", "titleFontSize", "headerFontSize" };
        private static string[] _doubleValues = { "buttonHeight", "stackSpacing", "buttonBorderWidth" };
        private static string[] _thicknessValues = { "basePadding", "sidePadding" };

        static DynamicStyleHelper()
        {
        }

        public static void CalculateAll()
        {
            CalculateDisplayCoef();
            CalculateDoubleValues();
            CalculateThicknessValues();
        }

        public static void ChangeFontSize(double offset)
        {
            foreach (var valueName in _fontSizeValues)
            {
                SetDynamicResource(valueName, (double)Application.Current.Resources[valueName] + offset * _displayCoef);
            }

        }

        public static void ChangeThickness(double offset)
        {
            foreach (var valueName in _thicknessValues)
            {
                Thickness thickness = (Thickness)App.Current.Resources[valueName];
                thickness.Left = thickness.Left + offset * _displayCoef;
                thickness.Right = thickness.Right + offset * _displayCoef;
                thickness.Top = thickness.Top + offset * _displayCoef;
                thickness.Bottom = thickness.Bottom + offset * _displayCoef;
                SetDynamicResource(valueName, thickness);
            }
        }

        private static void CalculateDoubleValues()
        {
            ResourceDictionary fontRes = new FontValues();
            foreach (string valueName in fontRes.Keys)
            {
                CalculateDouble(valueName);
            }
            ResourceDictionary doubleRes = new DoubleValues();
            foreach (string valueName in doubleRes.Keys)
            {

                CalculateDouble(valueName);
            }
        }

        private static void CalculateThicknessValues()
        {
            foreach (string valueName in _thicknessValues)
            {
                CalculateThickness(valueName);
            }
        }

        private static void CalculateDisplayCoef()
        {
            double d = DeviceDisplay.MainDisplayInfo.Density;
            double w = DeviceDisplay.MainDisplayInfo.Width;
            _displayCoef = (w / d) / (REFERENCE_WIDTH / REFERENCE_DENSITY);
        }

        private static void CalculateDouble(string resourceName)
        {
            double value = ((double)GetResourceValue(resourceName)) * _displayCoef;
            SetDynamicResource(resourceName, value);
        }

        private static void CalculateThickness(string resourceName)
        {
            Thickness thickness = (Thickness)GetResourceValue(resourceName);
            thickness.Left = thickness.Left * _displayCoef;
            thickness.Right = thickness.Right * _displayCoef;
            thickness.Top = thickness.Top * _displayCoef;
            thickness.Bottom = thickness.Bottom * _displayCoef;
            SetDynamicResource(resourceName, thickness);
        }

        private static void SetDynamicResource<T>(string resourceName, T value)
        {
            App.Current.Resources[resourceName] = value;
        }

        private static object GetResourceValue(string keyName)
        {
            if (Application.Current.Resources.TryGetValue(keyName, out var retVal))
            {
                return retVal;
            }
            return null;
        }
    }
}