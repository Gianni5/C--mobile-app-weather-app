using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace weatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class favoritePage : ContentPage
    {
        public favoritePage()
        {
            InitializeComponent();


        }

   
        
        private async void getWeather_Clicked(object sender, EventArgs e)
        {
            MyApi myapi = new MyApi();
            WeatherClass weather = await myapi.GetWeatherAsync(entry.Text);
            if (weather == null)
            {
                //there was a problem with the request
                await DisplayAlert("Alert", "Hopes was a problem with the request", "ok");
            }
            else 
            {
                Page1 page = new Page1(weather);
                await Navigation.PushModalAsync(page);
            }

        }

        private async void preference_Clicked(object sender, EventArgs e)
        {
            PreferencePage page = new PreferencePage();
            await Navigation.PushModalAsync(page);
        }
    }
}