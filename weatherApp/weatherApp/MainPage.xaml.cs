using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace weatherApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        
        MyApi myapi = new MyApi();
        public MainPage()
        {
            InitializeComponent();
            // pickerCity.Items.Add("Naples");  // adding to the picker
            // pickerCity.Items.Add("New York");  // adding to the picker
            //  pickerCity.Items.Add("London");  // adding to the picker
            // pickerCity.Items.Add("Perth");  // adding to the picker
            // pickerCity.Items.Add("Paris");  // adding to the picker
        }




        private void fetchButton_Clicked(object sender, EventArgs e)
        {
            // string convertedSelectedItem = (string)pickerCity.SelectedItem; // creating a variable that convert to string the selected items 

            // GetAPI(convertedSelectedItem);// call the method 

        }


                 //async when using await
        private async void naples_Clicked(object sender, EventArgs e)
        {
            WeatherClass weather = await myapi.GetWeatherAsync("Naples");
            //Page1 is a variable in this case when you create a new object
            Page1 page = new Page1(weather);
            await Navigation.PushModalAsync(page);

        }


        private async void newyork_Clicked(object sender, EventArgs e)
        {
            WeatherClass weather = await myapi.GetWeatherAsync("New York");
            //Page1 is a variable
            Page1 page = new Page1(weather);
            await Navigation.PushModalAsync(page);
        }

        private async void london_Clicked(object sender, EventArgs e)
        {
            WeatherClass weather = await myapi.GetWeatherAsync("London");
            //Page1 is a variable
            Page1 page = new Page1(weather);
            await Navigation.PushModalAsync(page);
        }

        private async void perth_Clicked(object sender, EventArgs e)
        {
            WeatherClass weather = await myapi.GetWeatherAsync("Perth");
            //Page1 is a variable
            Page1 page = new Page1(weather);
            await Navigation.PushModalAsync(page);
        }

        private async void paris_Clicked(object sender, EventArgs e)
        {
            WeatherClass weather = await myapi.GetWeatherAsync("Paris");
            //Page1 is a variable
            Page1 page = new Page1(weather);
            await Navigation.PushModalAsync(page);
        }

        private async void Search_Clicked(object sender, EventArgs e)
        {

            //favoritePage is a variable

            favoritePage page = new favoritePage();
            await Navigation.PushModalAsync(page);
        }
    }
}

