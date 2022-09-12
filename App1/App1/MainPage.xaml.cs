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
        public MainPage()
        {
            InitializeComponent();
        }

        private void UpText_Clicked(object sender, EventArgs e)
        {
            DynamicStyleHelper.ChangeFontSize(1);
        }

        private void DownText_Clicked(object sender, EventArgs e)
        {
            DynamicStyleHelper.ChangeFontSize(-1);
        }

        private void UpPadding_Clicked(object sender, EventArgs e)
        {
            DynamicStyleHelper.ChangeThickness(1);
        }

        private void DownPadding_Clicked(object sender, EventArgs e)
        {
            DynamicStyleHelper.ChangeThickness(-1);
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

        private void NextPage_Clicked(object sender, EventArgs e)
        {

        }
    }
}
