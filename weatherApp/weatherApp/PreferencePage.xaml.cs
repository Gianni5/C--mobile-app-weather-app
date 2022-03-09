using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace weatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreferencePage : ContentPage
    {
        public PreferencePage()
        {
            InitializeComponent();
            string Units = Preferences.Get("tempSign", "metric");
            if (Units == "metric")
            {
                fahrenheit.IsToggled = false;
            }
            else
            {
                fahrenheit.IsToggled = true;
            }

        }

        private void fahrenheit_Toggled(object sender, ToggledEventArgs e)
        {
            if (fahrenheit.IsToggled == true)
            {
                Preferences.Set("tempSign", "imperial");
            }
            else 
            {
                
                Preferences.Set("tempSign", "metric");
            }
        }

       
    }
}