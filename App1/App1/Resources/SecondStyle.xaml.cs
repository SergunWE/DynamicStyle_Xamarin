using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Resources
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondStyle : ResourceDictionary
    {
        public SecondStyle()
        {
            InitializeComponent();
        }
    }
}