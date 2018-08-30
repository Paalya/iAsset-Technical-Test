using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.BusinessLogic.Interface
{
    public interface ICityService
    {
        List<City> GetCities();
        List<City> GetCities(string country);
    }
}
