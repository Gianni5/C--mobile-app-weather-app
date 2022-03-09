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
    public partial class Page1 : ContentPage
    {

        public Page1(WeatherClass weather)
        {
            string simble = "C°";
            InitializeComponent();
            //Access page labels to update with the data from weather
            string Units = Preferences.Get("tempSign", "metric");
            if (Units == "imperial")
            {
                 simble = "F°";        
            }
            xcityName.Text = $"{weather.Name}"; 
            xdescription.Text = $"{weather.Description}"; 
            xmin.Text = $" Min: {weather.TempMin} {simble}";
            xmax.Text = $" Max: {weather.TempMax} {simble}";
            xfeel.Text = $" Feels: {weather.FeelsLike} {simble}";
            xhumidity.Text = $" Humidity: {weather.Humidity} %";
           
            xtemp.Text = $" {weather.Temp} {simble}";

        }
    }
}