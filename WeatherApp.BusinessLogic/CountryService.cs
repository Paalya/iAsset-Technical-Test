using System.Collections.Generic;
using Newtonsoft.Json;
using WeatherApp.BusinessLogic.Interface;
using WeatherApp.Models;

namespace WeatherApp.BusinessLogic
{
    public class CountryService : ICountryService
    {
        /// <summary>
        /// Reads the json file which consists of data related to Countries
        /// </summary>
        /// <returns>returns a list of countries</returns>
        public List<Country> GetCountries()
        {
            //Read data from json file
            const string countriesJson = "countries.json";
            string countries = Helper.JsonHelper.ReadDataFromResource(countriesJson);
            var data = JsonConvert.DeserializeObject<List<Country>>(countries);
            return data;
        }
    }
}
