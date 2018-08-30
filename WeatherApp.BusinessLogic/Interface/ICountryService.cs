using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.BusinessLogic.Interface
{
    public interface ICountryService
    {
        List<Country> GetCountries();
    }
}
