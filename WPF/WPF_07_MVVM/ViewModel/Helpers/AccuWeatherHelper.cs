using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WPF_07_MVVM.Model;

namespace WPF_07_MVVM.ViewModel.Helpers
{
    class AccuWeatherHelper
    {
        public const string BASE_URL = "http://dataservice.accuweather.com/";
        public const string API_KEY = "DFkZnGGZ5wKXdn4ZPVTGAburF4ej4Le9";
        public const string AUTOCOMPLETED_ENDPOIN = "locations/v1/cities/autocomplete?apikey={0}&q={1}";
        public const string CURRENT_CONDITIONS_ENDPOINT = "currentconditions/v1/{0}?apikey={1}";


        public static async Task<List<City>> GetCities(string query)
        {
            List<City> cities = new List<City>();

            string url = BASE_URL + String.Format(AUTOCOMPLETED_ENDPOIN, API_KEY, query);

            using (HttpClient client = new HttpClient())
            {
                var responce = await client.GetAsync(url);
                string json = await responce.Content.ReadAsStringAsync(); //get json data
                cities = JsonConvert.DeserializeObject<List<City>>(json); //parse
            }
            return cities;
        }

        public static async Task<CurrentCondition> GetCurrentConditions(string locationKey)
        {
            CurrentCondition currentCondition = new CurrentCondition();

            string url = BASE_URL + String.Format(CURRENT_CONDITIONS_ENDPOINT, locationKey, API_KEY);

            using (HttpClient client = new HttpClient())
            {
                var responce = await client.GetAsync(url);
                string json = await responce.Content.ReadAsStringAsync(); //get json data
                currentCondition = JsonConvert.DeserializeObject<List<CurrentCondition>>(json)[0]; //parse and get result
            }
            return currentCondition;
        }
    }
}
