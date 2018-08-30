using System.Collections.Generic;
using WeatherApp.BusinessLogic.Interface;
using WeatherApp.Models;
using Newtonsoft.Json;
using System.Linq;

namespace WeatherApp.BusinessLogic
{
    public class CityService : ICityService
    {
        /// <summary>
        /// Gets the list of cities defined in the json true file
        /// </summary>
        /// <returns>returns a list of all cities</returns>
        public List<City> GetCities()
        {
            //Read data from json file
            const string citiesJson = "cities.json";
            string cities = Helper.JsonHelper.ReadDataFromResource(citiesJson);
            var data = JsonConvert.DeserializeObject<List<City>>(cities);
            return data;
        }

        /// <summary>
        /// Gets the list of cities based on the country selected
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public List<City> GetCities(string country)
        {
            var cities = GetCities();
            var citiesUnderCountry = cities.Where(c => c.country == country).ToList();
            return citiesUnderCountry;
        }
    }
}
