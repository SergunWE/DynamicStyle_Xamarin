using App1.Helpers;
using App1.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public double HeaderSize { get; set; }
        public double TitleSize { get; set; }
        public double SimpleSize { get; set; }

        private bool _firstStyle = true;

        private double width = 1080;
        private double density = 2.75;

        public MainPage()
        {
            DynamicStyleHelper.CalculateAndSetValues(width, density, new FirstStyle());
            SetSizeLabels();
            InitializeComponent();
            BindingContext = this;
        }

        private void ThemeChange_Clicked(object sender, EventArgs e)
        {
            switch (Application.Current.RequestedTheme)
            {
                case OSAppTheme.Light:
                    Application.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
                case OSAppTheme.Dark:
                    Application.Current.UserAppTheme = OSAppTheme.Light;
                    break;
            }
        }

        private void StyleChange_Clicked(object sender, EventArgs e)
        {
            if(_firstStyle)
            {
                _firstStyle = false;
                DynamicStyleHelper.CalculateAndSetValues(width, density, new SecondStyle(), true);
            }
            else
            {
                _firstStyle = true;
                DynamicStyleHelper.CalculateAndSetValues(width, density, new FirstStyle(), true);
            }
            SetSizeLabels();
        }

        private void SetSizeLabels()
        {
            HeaderSize = (double)ResourceHelper.GetResource("headerFontSize");
            TitleSize = (double)ResourceHelper.GetResource("titleFontSize");
            SimpleSize = (double)ResourceHelper.GetResource("simpleFontSize");
            OnPropertyChanged("HeaderSize");
            OnPropertyChanged("TitleSize");
            OnPropertyChanged("SimpleSize");
        }
    }
}
