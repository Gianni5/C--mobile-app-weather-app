using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
namespace weatherApp
{
    public class MyApi
    {
        public async Task<WeatherClass> GetWeatherAsync(string City)
        {
            string Units = Preferences.Get("tempSign", "metric");
            //Preferences.Set("tempSign", "metric");  this set the preference
            //Fetch
            var client = new HttpClient();
            var response = await client.GetAsync("http://api.openweathermap.org/data/2.5/weather?q=" + City + "&appid=763b9ba6982366fb7201e0ff1db43034" + "&units=" + Units);
            if (response.StatusCode != System.Net.HttpStatusCode.OK) 
            {
                return null;
            }
            var responseString = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseString);


            //parse response into JSON
            //GET Whole Object 
            var obj = JsonConvert.DeserializeObject<JObject>(responseString);
            //Get name Object info for string 45 get inside the object check for the value in this case is a JSON array(JArray), get the name of the array(weather) and access the array position ([0]) accessthe value(string) which is a key name (description)
            //var name = obj.Value<JArray>("weather")[0].Value<string>("description");
            //Get USD Value
            string name = obj.Value<string>("name");
            string descriptioin = obj.Value<JArray>("weather")[0].Value<string>("description");
            string temp = obj.Value<JObject>("main").Value<string>("temp");
            string temp_min = obj.Value<JObject>("main").Value<string>("temp_min");
            string temp_max = obj.Value<JObject>("main").Value<string>("temp_max");
            string feels_like = obj.Value<JObject>("main").Value<string>("feels_like");
            string humidity = obj.Value<JObject>("main").Value<string>("humidity");

            //Update UI
            /*xcityName.Text = $"{City}: " + "\n" +
                $"{name}, " + "\n"+
                $" Descriptioin:{descriptioin}" + "\n" +
                $" Temperature:{temp}  " + "\n" +
                $" Min:{temp_min}"  + "\n" +
                $" Max:{temp_max}"  + "\n" +
                $" Feel Like:{feels_like}" + "\n" +
                $" Humidity:{humidity}" + "\n" +
                $" Time:{timezone} ";*/

            //iniitalise weather class with data
            WeatherClass weather = new WeatherClass();  // create new object
            weather.Name = name;  // I am accessing with . (the dot is used to access in this case to the class) to WeatherClass and grab the Name 
            weather.Description = descriptioin;
            weather.Temp = temp;
            weather.TempMax = temp_max;
            weather.TempMin = temp_min;
            weather.Humidity = humidity;
            weather.FeelsLike = feels_like;

            return weather; 

        }


    }

}
